using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.AddressDtos;
using Entities.DTOs.LoginInfoDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class LoginInfoController : ControllerBase
    {
        ILoginInfoService _loginInfoService;
        public LoginInfoController(ILoginInfoService loginInfoService)
        {
            _loginInfoService = loginInfoService;
        }
        [HttpPost("add")]
        public IActionResult Add([FromQuery] CreateLoginInfoDto loginInfo)
        {
            var result = _loginInfoService.Add(loginInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromQuery] UpdateLoginInfoDto loginInfo)
        {
            var result = _loginInfoService.Update(loginInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] DeleteLoginInfoDto loginInfo)
        {
            var result = _loginInfoService.Delete(loginInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _loginInfoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var result = _loginInfoService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
