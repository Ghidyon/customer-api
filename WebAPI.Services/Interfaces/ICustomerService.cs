using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models.Entities;

namespace WebAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetSingleCustomer(Guid id);

        Task<IEnumerable<Customer>> GetCustomersAsync();

        Task<Customer> GetCustomerByAccountNumber(string AccountNumber);
    }
}
