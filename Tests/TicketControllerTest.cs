using AareonTechnicalTest.Controller;
using AareonTechnicalTest.Mapper;
using Common.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UseCases;
using UseCases.Services;
using UseCases.TicketUseCase;
using UseCases.ViewModels;
using Xunit;
using FluentAssertions;
namespace Tests
{
    [Collection("Non-Parallel Collection")]
    public class TicketControllerTest
    {
        private readonly TicketController _controller;
        private readonly ITicketService _service;
        private readonly ApplicationContext appContext;

        public TicketControllerTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>()
           .UseInMemoryDatabase(databaseName: "TestDatabase");

            appContext = new ApplicationContext(optionsBuilder.Options);
            appContext.Database.EnsureDeleted();
            appContext.Database.EnsureCreated();

            _service = new TicketService(appContext);
            _controller = new TicketController(_service, new CreateTicketUseCase(_service), new UpdateTicketUseCase(_service), new DeleteTicketUseCase(_service), new DisplayTicketUseCase(_service), new DisplayAllTicketUseCase(_service));
        }

        [Fact]
        public void When_GetAllTickets_Called_Should_Return_AllItems()
        {
            //Arrange
            MockDataProvider.GeneratePersonAndTicketTestData(appContext);
            // Act
            IActionResult response = _controller.GetAll();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(response);
            var Tickets = Assert.IsType<Result<List<Ticket>>>(actionResult.Value);
            Tickets.Data.Count.Should().Be(1);
        }
        [Fact]
        public void When_GetTicketByID_Called_Should_ReturnSucess()
        {
            //Arrange
            MockDataProvider.GeneratePersonAndTicketTestData(appContext);

            // Act
            IActionResult response = _controller.GetById(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(response);
            var Ticket = Assert.IsType<Result<Ticket>>(actionResult.Value);
            Ticket.Data.Id.Should().Be(1);
        }
        [Fact]
        public void When_CreateTicket_Called_Should_ReturnSucess()
        {
            //Arrange
            var Ticket = new CreateTicketRequest();
            Ticket.Content = "Ticket For System Maintanance";
            Ticket.PersonId = 1;

            // Act
            var result = _controller.Create(Ticket);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var responseModel = Assert.IsType<Result<ResponseModel>>(actionResult.Value);
            Assert.True(responseModel.Succeeded);
            var saveTicket = appContext.Tickets.FirstOrDefault();
            Ticket.Content.Should().Be("Ticket For System Maintanance");
        }
        [Fact]
        public void When_UpdateTicket_Called_Should_ReturnSucess()
        {
            //Arrange
            MockDataProvider.GeneratePersonAndTicketTestData(appContext);

            var Ticket = _service.GetTicketDetailsById(1);
            Ticket.Content = "Ticket Content Updated.";

            var TicketUpdate = TicketMapper.GetUpdateTicket(Ticket);
            // Act
            var result = _controller.Update(TicketUpdate);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var responseModel = Assert.IsType<Result<ResponseModel>>(actionResult.Value);
            Assert.True(responseModel.Succeeded);
            Ticket = appContext.Tickets.Where(x => x.Id == 1).FirstOrDefault();
            Ticket.Content.Should().Be("Ticket Content Updated.");
        }
        [Fact]
        public void When_DeleteTicket_Called_Should_ReturnSucess()
        {
            //Arrange
            MockDataProvider.GeneratePersonAndTicketTestData(appContext);
            var Ticket = _service.GetTicketDetailsById(1);

            // Act
            var result = _controller.Delete(Ticket.Id);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var responseModel = Assert.IsType<Result<ResponseModel>>(actionResult.Value);
            Assert.True(responseModel.Succeeded);
            Ticket = appContext.Tickets.Where(x => x.Id == 1).FirstOrDefault();
            Ticket.Should().BeNull();
        }
    }
}
