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
        private readonly TicketsController _controller;
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
            _controller = new TicketsController(_service, new CreateTicketUseCase(_service), new UpdateTicketUseCase(_service), new DeleteTicketUseCase(_service), new DisplayTicketUseCase(_service), new DisplayAllTicketUseCase(_service));
        }

        [Fact]
        public void When_GetAllTickets_Called_Should_Return_AllItems()
        {
            //Arrange
            MockDataProvider.GeneratePersonAndTicketTestData(appContext);
            // Act
            IActionResult response = _controller.GetAllTickets();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(response);
            var Tickets = Assert.IsType<List<Ticket>>(actionResult.Value);
            Tickets.Count.Should().Be(1);
        }
        [Fact]
        public void When_GetTicketByID_Called_Should_ReturnSucess()
        {
            //Arrange
            MockDataProvider.GeneratePersonAndTicketTestData(appContext);

            // Act
            IActionResult response = _controller.GetTicketById(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(response);
            var Ticket = Assert.IsType<Ticket>(actionResult.Value);
            Ticket.Id.Should().Be(1);
        }
        [Fact]
        public void When_CreateTicket_Called_Should_ReturnSucess()
        {
            //Arrange
            var Ticket = new CreateTicketRequest();
            Ticket.Content = "Ticket For System Maintanance";
            Ticket.PersonId = 1;

            // Act
            var result = _controller.CreateTicket(Ticket);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var responseModel = Assert.IsType<ResponseModel>(actionResult.Value);
            Assert.True(responseModel.IsSuccess);
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
            var result = _controller.UpdateTicket(TicketUpdate);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var responseModel = Assert.IsType<ResponseModel>(actionResult.Value);
            Assert.True(responseModel.IsSuccess);
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
            var result = _controller.DeleteTicket(Ticket.Id);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var responseModel = Assert.IsType<ResponseModel>(actionResult.Value);
            Assert.True(responseModel.IsSuccess);
            Ticket = appContext.Tickets.Where(x => x.Id == 1).FirstOrDefault();
            Ticket.Should().BeNull();
        }
    }
}
