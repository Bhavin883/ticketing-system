using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int PersonId { get; set; }
        public string Content { get; set; }
    }
    
}
