using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models.DataTransferObjects
{
    public class ViewBalanceDto
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
