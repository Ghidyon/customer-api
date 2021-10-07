using Microsoft.AspNetCore.Http;
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

        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> GetBalance(string accountNumber)
        {
            return Ok(await _accountService.GetAccountBalance(accountNumber));
        }

        /*[HttpGet("{accountNumber}/deposit}")]
        [HttpGet("{accountNumber}/withdraw}")]*/
    }
}
