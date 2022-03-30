using System;
using System.Collections.Generic;
using System.Linq;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using UseCases.ViewModels;

namespace UseCases.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationContext _context;
        public TicketService(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get list of all Ticket
        /// </summary>
        /// <returns></returns>
        public List<Ticket> GetTicketList()
        {
            return _context.Tickets.Include(t => t.Notes).ToList();
        }

        /// <summary>
        /// get Ticket details by Ticket id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Ticket GetTicketDetailsById(int Id)
        {
            return _context.Tickets.Include(t => t.Notes).Where(x => x.Id == Id).FirstOrDefault();
        }

        /// <summary>
        ///  add Ticket
        /// </summary>
        /// <param name="TicketModel"></param>
        /// <returns></returns>
        public ResponseModel CreateTicket(Ticket ticket)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                _context.Add<Ticket>(ticket);
                _context.SaveChanges();
                model.Messsage = "Ticket has been created successfully";
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.Messsage = "Error : " + ex.Message;
                model.IsSuccess = false;
            }
            return model;

        }

        /// <summary>
        ///  edit Ticket
        /// </summary>
        /// <param name="TicketModel"></param>
        /// <returns></returns>
        public ResponseModel UpdateTicket(Ticket ticket)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Ticket _ticket = GetTicketDetailsById(ticket.Id);

                _ticket.Content = ticket.Content;
                _ticket.PersonId = ticket.PersonId;
                _context.Update<Ticket>(_ticket);
                model.Messsage = "Ticket has been updated successfully";
                model.IsSuccess = true;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                model.Messsage = "Error : " + ex.Message;
                model.IsSuccess = false;
            }
            return model;
        }

        /// <summary>
        /// delete Ticket
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ResponseModel DeleteTicket(int Id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Ticket _ticket = GetTicketDetailsById(Id);
                if (_ticket != null)
                {
                    _context.Remove<Ticket>(_ticket);
                    _context.SaveChanges();
                    model.Messsage = "Ticket has been deleted successfully";
                    model.IsSuccess = true;
                }
                else
                {
                    model.Messsage = "Ticket not found for given Id";
                    model.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                model.Messsage = "Error : " + ex.Message;
                model.IsSuccess = false;
            }
            return model;
        }

    }
}
