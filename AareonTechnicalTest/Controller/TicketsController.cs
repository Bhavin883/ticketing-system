using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UseCases.Services;
using UseCases.TicketUseCase;

namespace AareonTechnicalTest.Controller
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class TicketsController : ControllerBase
    {
        ITicketService _TicketService;
        ICreateTicketUseCase _CreateTicketUseCase;
        IUpdateTicketUseCase _UpdateTicketUseCase;
        IDeleteTicketUseCase _DeleteTicketUseCase;
        IDisplayTicketUseCase _DisplayTicketUseCase;
        IDisplayAllTicketUseCase _DisplayAllTicketUseCase;
        public TicketsController(ITicketService service, 
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
        /// Get all tickets
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllTickets()
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
        /// Get ticket by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("id")]
        public IActionResult GetTicketById(int id)
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
        /// Save ticket
        /// </summary>
        /// <param name="TicketModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateTicket(CreateTicketRequest TicketModel)
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
        /// Update ticket
        /// </summary>
        /// <param name="TicketModel"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateTicket(UpdateTicketRequest TicketModel)
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
        /// Delete ticket  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteTicket(int id)
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
