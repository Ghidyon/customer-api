using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Interfaces;
using WebAPI.Models.Entities;
using WebAPI.Services.Interfaces;
using WebAPI.Models.DataTransferObjects;
using WebAPI.Models.Enumerators;
using AutoMapper;

namespace WebAPI.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Account> _accountRepo;
        private readonly IServiceFactory _serviceFactory;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IServiceFactory serviceFactory, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _accountRepo = unitOfWork.GetRepository<Account>();
            _serviceFactory = serviceFactory;
            _mapper = mapper;
        }

        public async Task<ViewTransactionDto> Deposit(string accountNumber, decimal amount)
        {
            if (amount <= 0)
            {
                return null;
            }

            var customerAccount = await Task.FromResult(_accountRepo.GetSingleByCondition(a => a.Number == accountNumber));

            if (customerAccount is null)
                return null;

            customerAccount.Balance += amount;
            var account = await _accountRepo.UpdateAsync(customerAccount);

            ITransactionService transactionService = _serviceFactory.GetService<ITransactionService>();
            var transaction = new Transaction
            {
                CustomerId = account.CustomerId,
                TransactionMode = TransactionMode.Credit,
                Number = account.Number,
                Amount = amount,
                TimeStamp = DateTime.Now
            };

            var transactionDetails = await transactionService.AddTransaction(transaction);
            return _mapper.Map<ViewTransactionDto>(transactionDetails);
        }

        public async Task<decimal> GetAccountBalance(string accountNumber)
        {
            var account = await Task.FromResult(_accountRepo.GetSingleByCondition(a => a.Number == accountNumber));
            return account.Balance;
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await _accountRepo.GetAllAsync();
        }

        public async Task<ViewAccountDto> GetByAccountNumber(string accountNumber)
        {
            Account customerAccount = await Task.FromResult(_accountRepo.GetByCondition(a => a.Number == accountNumber, includeProperties: "Customer").FirstOrDefault());
            return _mapper.Map<ViewAccountDto>(customerAccount);
        }

        public async Task<ViewTransactionDto> Withdraw(string accountNumber, decimal amount)
        {
            if (amount <= 0)
            {
                return null;
            }

            var customerAccount = await Task.FromResult(_accountRepo.GetSingleByCondition(a => a.Number == accountNumber));

            if (customerAccount is null)
                return null;

            if (customerAccount.Balance < amount)
                return null;

            customerAccount.Balance -= amount;
            var account = await _accountRepo.UpdateAsync(customerAccount);

            ITransactionService transactionService = _serviceFactory.GetService<ITransactionService>();
            var transaction = new Transaction
            {
                CustomerId = account.CustomerId,
                TransactionMode = TransactionMode.Debit,
                Number = account.Number,
                Amount = amount,
                TimeStamp = DateTime.Now
            };

            var transactionDetails = await transactionService.AddTransaction(transaction);
            return _mapper.Map<ViewTransactionDto>(transactionDetails);
        }
    }
}
