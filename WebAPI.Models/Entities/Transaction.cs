using System;
using WebAPI.Models.Enumerators;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string Number { get; set; }
        public TransactionMode TransactionMode { get; set; }
        [Column(TypeName = "decimal(38,2)")]
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
