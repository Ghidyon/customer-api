using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models.Entities;
using WebAPI.Models.DataTransferObjects;

namespace WebAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetSingleCustomerAsync(Guid id);

        Task<IEnumerable<Customer>> GetCustomersAsync();

        Task<ViewAccountDto> GetCustomerByAccountNumber(string AccountNumber);
    }
}
