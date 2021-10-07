using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models.Entities;
using WebAPI.Models.DataTransferObjects;

namespace WebAPI.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<decimal> GetAccountBalance(string accountNumber);
        Task<decimal> Withdraw(string accountNumber, decimal amount);
        Task<bool> Deposit(string accountNumber, decimal amount);
        Task<ViewAccountDto> GetByAccountNumber(string accountNumber);
    }
}
