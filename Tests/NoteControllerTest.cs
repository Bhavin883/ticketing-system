using AareonTechnicalTest.Controller;
using AareonTechnicalTest.Mapper;
using Common.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UseCases;
using UseCases.NoteUseCase;
using UseCases.Services;
using UseCases.ViewModels;
using Xunit;

namespace Tests
{
    [Collection("Non-Parallel Collection")]
    public class NoteControllerTest
    {
        private readonly NoteController _controller;
        private readonly INoteService _service;
        private ApplicationContext appContext;
        public NoteControllerTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>()
           .UseInMemoryDatabase(databaseName: "TestDatabase");

            appContext = new ApplicationContext(optionsBuilder.Options);
            appContext.Database.EnsureDeleted();
            appContext.Database.EnsureCreated();
            _service = new NoteService(appContext);
            _controller = new NoteController(_service, new CreateNoteUseCase(_service), new UpdateNoteUseCase(_service), new DeleteNoteUseCase(_service), new DisplayNoteUseCase(_service), new DisplayAllNoteUseCase(_service));
        }
        [Fact]
        public void When_GetAllNotes_Called_Should_Return_AllItems()
        {
            //Arrange
            MockDataProvider.GeneratePersonAndTicketTestData(appContext);
            MockDataProvider.GenerateNoteTestData(appContext);

            // Act
            IActionResult response = _controller.GetAll();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(response);
            var Notes = Assert.IsType<Result<List<Note>>>(actionResult.Value);
            Assert.Equal(2, Notes.Data.Count);

        }
        [Fact]
        public void When_GetNoteByID_Called_Should_ReturnSucess()
        {
            //Arrange
            MockDataProvider.GeneratePersonAndTicketTestData(appContext);
            MockDataProvider.GenerateNoteTestData(appContext);

            // Act
            IActionResult response = _controller.GetById(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(response);
            var note = Assert.IsType<Result<Note>>(actionResult.Value);

            Assert.Equal(1, note.Data.Id);
        }
        [Fact]
        public void When_CreateNote_Called_Should_ReturnSucess()
        {
            //Arrange
            MockDataProvider.GeneratePersonAndTicketTestData(appContext);
            var note = new CreateNoteRequest();
            note.TicketId = 1;
            note.Content = "Add Pie chart for customer share";
            note.PersonId = 1;

            // Act
            var result = _controller.Create(note);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var responseModel = Assert.IsType<Result<ResponseModel>>(actionResult.Value);
            Assert.True(responseModel.Succeeded);
            var saveNote = appContext.Notes.FirstOrDefault();
            Assert.Equal("Add Pie chart for customer share", saveNote.Content);
        }
        [Fact]
        public void When_UpdateNote_Called_Should_ReturnSucess()
        {
            //Arrange
            MockDataProvider.GeneratePersonAndTicketTestData(appContext);
            MockDataProvider.GenerateNoteTestData(appContext);
            var note = _service.GetNoteDetailsById(1);
            note.Content = "Configure data source from db.";

            var noteUpdate = NoteMapper.GetUpdateNote(note);
            // Act
            var result = _controller.Update(noteUpdate);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var responseModel = Assert.IsType<Result<ResponseModel>>(actionResult.Value);
            Assert.True(responseModel.Succeeded);
            note = appContext.Notes.Where(x => x.Id == 1).FirstOrDefault();
            Assert.Equal("Configure data source from db.", note.Content);
        }
        [Fact]
        public void When_DeleteNote_Called_Should_ReturnSucess()
        {
            //Arrange
            MockDataProvider.GeneratePersonAndTicketTestData(appContext);
            MockDataProvider.GenerateNoteTestData(appContext);
            var note = new DeleteNoteRequest() { Id = 1, IsAdmin = true };

            // Act
            var result = _controller.Delete(note);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var responseModel = Assert.IsType<Result<ResponseModel>>(actionResult.Value);
            Assert.True(responseModel.Succeeded);
            var delNote = appContext.Notes.Where(x => x.Id == 1).FirstOrDefault();
            Assert.Null(delNote);
        }
        [Fact]
        public void When_DeleteNote_Called_And_UserIs_NotAdmin_Should_NotAllow()
        {
            //Arrange
            MockDataProvider.GeneratePersonAndTicketTestData(appContext);
            MockDataProvider.GenerateNoteTestData(appContext);
            var note = new DeleteNoteRequest() { Id = 1, IsAdmin = false };

            // Act
            var result = _controller.Delete(note);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var responseModel = Assert.IsType<Result<ResponseModel>>(actionResult.Value);
            Assert.Equal("Note can not be deleted, Contact administrator", responseModel.Data.Messsage);

        }
    }
}
