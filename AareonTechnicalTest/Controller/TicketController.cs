using System;
using Microsoft.AspNetCore.Mvc;
using UseCases.Services;
using UseCases.TicketUseCase;

namespace AareonTechnicalTest.Controller
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class TicketController : ControllerBase
    {
        ITicketService _TicketService;
        ICreateTicketUseCase _CreateTicketUseCase;
        IUpdateTicketUseCase _UpdateTicketUseCase;
        IDeleteTicketUseCase _DeleteTicketUseCase;
        IDisplayTicketUseCase _DisplayTicketUseCase;
        IDisplayAllTicketUseCase _DisplayAllTicketUseCase;
        public TicketController(ITicketService service, 
            ICreateTicketUseCase createTicketUseCase, 
            IUpdateTicketUseCase updateTicketUseCase,
            IDeleteTicketUseCase deleteTicketUseCase,
            IDisplayTicketUseCase displayTicketUseCase,
            IDisplayAllTicketUseCase displayAllTicketUseCase)
        {
            _TicketService = service;
            _CreateTicketUseCase = createTicketUseCase;
            _UpdateTicketUseCase = updateTicketUseCase;
            _DeleteTicketUseCase = deleteTicketUseCase;
            _DisplayTicketUseCase = displayTicketUseCase;
            _DisplayAllTicketUseCase = displayAllTicketUseCase;
        }

        /// <summary>
        /// get all Tickets
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                var Tickets = _DisplayAllTicketUseCase.Handle(0);
                if (Tickets == null)
                    return NotFound();
                return Ok(Tickets);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// get Ticket details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetById(int id)
        {
            try
            {
                var Tickets = _DisplayTicketUseCase.Handle(id);
                if (Tickets == null)
                    return NotFound();
                return Ok(Tickets);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// save Ticket
        /// </summary>
        /// <param name="TicketModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(CreateTicketRequest TicketModel)
        {
            try
            {
                var model = _CreateTicketUseCase.Handle(TicketModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// update Ticket
        /// </summary>
        /// <param name="TicketModel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public IActionResult Update(UpdateTicketRequest TicketModel)
        {
            try
            {
                var model = _UpdateTicketUseCase.Handle(TicketModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// delete Ticket  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = _DeleteTicketUseCase.Handle(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
