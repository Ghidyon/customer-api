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

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody]DepositDto deposit)
        {
            if (deposit is null)
                return BadRequest("deposit parameter is null");
            
            var transactionDto = await _accountService.Deposit(deposit.AccountNumber, (decimal)deposit.Amount);
            if (transactionDto is null)
            {
                return NotFound("Invalid parameters");
            }

            //return CreatedAtRoute("AccountByNumber", new { id = transactionDto.Number }, transactionDto);
            return Ok(transactionDto);
        }
        //[HttpGet("{accountNumber}/withdraw}")]
    }
}
