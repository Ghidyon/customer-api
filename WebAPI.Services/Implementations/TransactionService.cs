using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Interfaces;
using WebAPI.Models.Entities;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Transaction> _transactionRepo;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _transactionRepo = unitOfWork.GetRepository<Transaction>();
        }
        
        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            return await _transactionRepo.AddAsync(transaction);
        }

    }
}
