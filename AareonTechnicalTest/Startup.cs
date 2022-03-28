using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UseCases;
using UseCases.Services;
using UseCases.TicketUseCase;
using UseCases.NoteUseCase;
using System;

namespace AareonTechnicalTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var DatabasePath = $"{Environment.CurrentDirectory}{System.IO.Path.DirectorySeparatorChar}Ticketing.db";
            services.AddDbContext<ApplicationContext>(c => c.UseSqlite($"Data Source={DatabasePath}"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AareonTechnicalTest", Version = "v1" });
               
            });
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<ICreateTicketUseCase, CreateTicketUseCase>();
            services.AddScoped<IUpdateTicketUseCase, UpdateTicketUseCase>();
            services.AddScoped<IDeleteTicketUseCase, DeleteTicketUseCase>();
            services.AddScoped<IDisplayTicketUseCase, DisplayTicketUseCase>();
            services.AddScoped<IDisplayAllTicketUseCase, DisplayAllTicketUseCase>();
            services.AddScoped<ICreateNoteUseCase, CreateNoteUseCase>();
            services.AddScoped<IUpdateNoteUseCase, UpdateNoteUseCase>();
            services.AddScoped<IDeleteNoteUseCase, DeleteNoteUseCase>();
            services.AddScoped<IDisplayNoteUseCase, DisplayNoteUseCase>();
            services.AddScoped<IDisplayAllNoteUseCase, DisplayAllNoteUseCase>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AareonTechnicalTest v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>{ endpoints.MapControllers();});
        }
    }
}
