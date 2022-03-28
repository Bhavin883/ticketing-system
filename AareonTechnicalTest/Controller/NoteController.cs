using System;
using Microsoft.AspNetCore.Mvc;
using UseCases.NoteUseCase;
using UseCases.Services;
namespace AareonTechnicalTest.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        INoteService _NoteService;
        ICreateNoteUseCase _CreateNoteUseCase;
        IUpdateNoteUseCase _UpdateNoteUseCase;
        IDeleteNoteUseCase _DeleteNoteUseCase;
        IDisplayNoteUseCase _DisplayNoteUseCase;
        IDisplayAllNoteUseCase _DisplayAllNoteUseCase;
        public NoteController(INoteService service,
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
        /// get all Notes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
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
        /// get Note details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetById(int id)
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
        /// update Note
        /// </summary>
        /// <param name="Note"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(CreateNoteRequest Note)
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
        /// save Note
        /// </summary>
        /// <param name="Note"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public IActionResult Update(UpdateNoteRequest Note)
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
        /// delete Note  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DeleteNoteRequest Note)
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
