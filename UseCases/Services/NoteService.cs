using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.ViewModels;

namespace UseCases.Services
{
    public class NoteService : INoteService
    {
        private readonly ApplicationContext _context;
        public NoteService(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get list of all Note
        /// </summary>
        /// <returns></returns>
        public List<Note> GetNoteList()
        {
            return _context.Set<Note>().ToList();
        }

        /// <summary>
        /// get Note details by Note id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Note GetNoteDetailsById(int Id)
        {
            return _context.Find<Note>(Id);
        }

        /// <summary>
        ///  add Note
        /// </summary>
        /// <param name="Note"></param>
        /// <returns></returns>
        public ResponseModel CreateNote(Note Note)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                _context.Add<Note>(Note);
                model.Messsage = "Note created successfully";
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
        ///  edit Note
        /// </summary>
        /// <param name="Note"></param>
        /// <returns></returns>
        public ResponseModel UpdateNote(Note Note)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Note _note = GetNoteDetailsById(Note.Id);

                if (_note == null)
                {
                    throw new Exception("Note not found for given Id.");
                    model.IsSuccess = false;

                }
                _note.Content = Note.Content;
                _note.PersonId = Note.PersonId;
                _note.TicketId = Note.TicketId;
                _context.Update<Note>(_note);
                model.Messsage = "Note has been updated successfully";
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
        /// delete Note
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ResponseModel DeleteNote(int Id, bool IsAdmin)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                if (IsAdmin)
                {
                    Note _note = GetNoteDetailsById(Id);
                    if (_note != null)
                    {
                        _context.Remove<Note>(_note);
                        _context.SaveChanges();
                        model.Messsage = "Note has been deleted successfully";
                        model.IsSuccess = true;
                    }
                    else
                    {
                        model.Messsage = "Note Not Found";
                        model.IsSuccess = false;
                    }
                }
                else
                {
                    model.Messsage = "Note can not be deleted, Contact administrator";
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
