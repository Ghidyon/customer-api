using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(Customer), 200)]
        public async Task<IActionResult> Customers()
        {
            return Ok(await _customerService.GetCustomersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SingleCustomer(Guid id)
        {
            return Ok(await _customerService.GetSingleCustomerAsync(id));
        }

        [HttpGet("customerAccountDetail/{accountNumber}")]
        public async Task<IActionResult> AccountDetail(string accountNumber)
        {
            return Ok(await _customerService.GetCustomerByAccountNumber(accountNumber));
        }
    }
}
