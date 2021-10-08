using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;
using WebAPI.Models.Entities;
using WebAPI.Models.DataTransferObjects;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(Account), 200)]
        public async Task<IActionResult> Accounts()
        {
            return Ok(await _accountService.GetAccountsAsync());
        }

        [HttpGet("{accountNumber}", Name = "AccountByNumber")]
        public async Task<IActionResult> Account(string accountNumber)
        {
            return Ok(await _accountService.GetByAccountNumber(accountNumber));
        }
        
        [HttpGet("{accountNumber}/balance")]
        public async Task<IActionResult> GetBalance(string accountNumber)
        {
            return Ok(await _accountService.GetAccountBalance(accountNumber));
        }

        [HttpPost("{accountNumber}/deposit")]
        public async Task<IActionResult> Deposit(string accountNumber, [FromBody]TransactDto deposit)
        {
            if (deposit is null)
                return BadRequest("empty parameter");
            
            var transactionDto = await _accountService.Deposit(accountNumber, deposit.Amount);
            if (transactionDto is null)
            {
                return NotFound("Invalid parameter");
            }

            return Ok(transactionDto);
        }

        [HttpPost("{accountNumber}/withdraw")]
        public async Task<IActionResult> Withdraw(string accountNumber, [FromBody]TransactDto withdrawal)
        {
            if (withdrawal is null)
                return BadRequest("empty parameter");

            var transactionDto = await _accountService.Withdraw(accountNumber, withdrawal.Amount);
            if (transactionDto is null)
            {
                return NotFound("Invalid parameter");
            }

            return Ok(transactionDto);
        }
    }
}
