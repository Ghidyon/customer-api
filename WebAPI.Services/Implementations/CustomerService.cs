using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models.Entities;
using WebAPI.Services.Interfaces;
using WebAPI.Data.Interfaces;

namespace WebAPI.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Customer> _customerRepo;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _customerRepo = unitOfWork.GetRepository<Customer>();
        }

        public async Task<Customer> GetCustomerByAccountNumber(string AccountNumber)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetSingleCustomer(Guid id)
        {
            return await Task.FromResult(_customerRepo.GetSingleByCondition(x => x.Id.Equals(id)));
        }
    }
}
