using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models.Entities;

namespace WebAPI.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccounts();

        Task<decimal> GetAccountBalance(string AccountNumber);

        Task<decimal> Withdraw(string AccountNumber, decimal amount);

        Task<bool> Deposit(string AccountNumber, decimal amount);
    }
}
