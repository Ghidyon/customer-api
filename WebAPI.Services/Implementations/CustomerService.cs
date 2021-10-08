using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models.Entities;
using WebAPI.Services.Interfaces;
using WebAPI.Data.Interfaces;
using WebAPI.Models.DataTransferObjects;

namespace WebAPI.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Customer> _customerRepo;
        private readonly IServiceFactory _serviceFactory;

        public CustomerService(IUnitOfWork unitOfWork, IServiceFactory serviceFactory)
        {
            _unitOfWork = unitOfWork;
            _serviceFactory = serviceFactory;
            _customerRepo = unitOfWork.GetRepository<Customer>();
        }

        public async Task<ViewAccountDto> GetCustomerByAccountNumber(string accountNumber)
        {
            IAccountService accountService = _serviceFactory.GetService<IAccountService>();
            var customerAccountDto = await accountService.GetByAccountNumber(accountNumber);

            return customerAccountDto;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _customerRepo.GetAllAsync();
        }

        public async Task<Customer> GetSingleCustomerAsync(Guid id)
        {
            return await Task.FromResult(_customerRepo.GetSingleByCondition(x => x.Id.Equals(id)));
        }
    }
}
