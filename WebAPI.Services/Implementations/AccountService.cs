using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Interfaces;
using WebAPI.Models.Entities;
using WebAPI.Services.Interfaces;
using WebAPI.Models.DataTransferObjects;
using AutoMapper;

namespace WebAPI.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Account> _accountRepo;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _accountRepo = unitOfWork.GetRepository<Account>();
            _mapper = mapper;
        }

        public Task<bool> Deposit(string accountNumber, decimal amount)
        {
            throw new NotImplementedException();
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

        public Task<decimal> Withdraw(string AccountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
