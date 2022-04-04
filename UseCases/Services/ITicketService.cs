using System.Collections.Generic;
using Common.Entities;
using UseCases.ViewModels;

namespace UseCases.Services
{
    public interface ITicketService
    {
        /// <summary>
        /// get list of all Ticket
        /// </summary>
        /// <returns></returns>
        List<Ticket> GetTicketList();

        /// <summary>
        /// get Ticket details by Ticket id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Ticket GetTicketDetailsById(int Id);

        /// <summary>
        ///  add Ticket
        /// </summary>
        /// <param name="TicketModel"></param>
        /// <returns></returns>
        ResponseModel CreateTicket(Ticket Ticket);

        /// <summary>
        ///  add Ticket
        /// </summary>
        /// <param name="TicketModel"></param>
        /// <returns></returns>
        ResponseModel UpdateTicket(Ticket Ticket);

        /// <summary>
        /// delete Ticket
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ResponseModel DeleteTicket(int Id);
    }
}

