using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.AccountDtos;
using Entities.DTOs.CustomerDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("add")]
        public IActionResult Add([FromQuery] CreateAccountDto account)
        {
            var result = _accountService.Add(account);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromQuery] UpdateAccountDto account)
        {
            var result = _accountService.Update(account);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] DeleteAccountDto account)
        {
            var result = _accountService.Delete(account);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _accountService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var result = _accountService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
