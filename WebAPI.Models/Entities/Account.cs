using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(38,2)")]
        public decimal Balance { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
