using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public int PersonId { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
