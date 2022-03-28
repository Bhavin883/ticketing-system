using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class Audit
    {
        [Key]
        public int AuditId { get; set; }
        public string TransactionType { get; set; }
        public string AffectedTable { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string AffectedColumns { get; set; }
        public string Key { get; set; }
    }
}
