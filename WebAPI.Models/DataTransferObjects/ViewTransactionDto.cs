using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models.Enumerators;

namespace WebAPI.Models.DataTransferObjects
{
    public class ViewTransactionDto
    {
        public Guid CustomerId { get; set; }
        public string AccountNumber { get; set; }
        public string TransactionMode { get; set; }
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
