using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UseCases.NoteUseCase;
using UseCases.Services;
namespace AareonTechnicalTest.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        INoteService _NoteService;
        ICreateNoteUseCase _CreateNoteUseCase;
        IUpdateNoteUseCase _UpdateNoteUseCase;
        IDeleteNoteUseCase _DeleteNoteUseCase;
        IDisplayNoteUseCase _DisplayNoteUseCase;
        IDisplayAllNoteUseCase _DisplayAllNoteUseCase;
        public NotesController(INoteService service,
            ICreateNoteUseCase createNoteUseCase,
            IUpdateNoteUseCase updateNoteUseCase,
            IDeleteNoteUseCase deleteNoteUseCase,
            IDisplayNoteUseCase displayNoteUseCase,
            IDisplayAllNoteUseCase displayAllNoteUseCase)
        {
            _NoteService = service;
            _CreateNoteUseCase = createNoteUseCase;
            _UpdateNoteUseCase = updateNoteUseCase;
            _DeleteNoteUseCase = deleteNoteUseCase;
            _DisplayNoteUseCase = displayNoteUseCase;
            _DisplayAllNoteUseCase = displayAllNoteUseCase;
        }

        /// <summary>
        /// Get all notes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllNotes()
        {
            try
            {
                var Notes = _DisplayAllNoteUseCase.Handle(0);
                if (Notes == null)
                    return NotFound();
                return Ok(Notes);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Get note by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("id")]
        public IActionResult GetNotesById(int id)
        {
            try
            {
                var Notes = _DisplayNoteUseCase.Handle(id);
                if (Notes == null)
                    return NotFound();
                return Ok(Notes);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update note
        /// </summary>
        /// <param name="Note"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateNote(CreateNoteRequest Note)
        {
            try
            {
                var model = _CreateNoteUseCase.Handle(Note);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Save note
        /// </summary>
        /// <param name="Note"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateNote(UpdateNoteRequest Note)
        {
            try
            {
                var model = _UpdateNoteUseCase.Handle(Note);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Delete note  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteNote(DeleteNoteRequest Note)
        {
            try
            {
                var model = _DeleteNoteUseCase.Handle(Note);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
