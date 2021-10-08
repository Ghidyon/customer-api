using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models.Entities;
using WebAPI.Models.DataTransferObjects;
using WebAPI.Models.Enumerators;

namespace WebAPI.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<ViewBalanceDto> GetAccountBalance(string accountNumber);
        Task<ViewTransactionDto> Withdraw(string accountNumber, decimal amount);
        Task<ViewTransactionDto> Deposit(string accountNumber, decimal amount);
        Task<ViewAccountDto> GetByAccountNumber(string accountNumber);
    }
}
