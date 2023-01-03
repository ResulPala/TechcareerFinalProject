using Business.Abstract;
using Entities.DTOs.CustomerRegistryInformationDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]

        public ActionResult Login([FromQuery] CustomerForLoginDto customerForLoginDto)
        {
            var customerToLogin = _authService.Login(customerForLoginDto);
            if (!customerToLogin.Success)
            {
                return BadRequest(customerToLogin.Message);
            }
            var result = _authService.CreateAccessToken(customerToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        
        public ActionResult Register([FromQuery] CustomerForRegisterDto customerForRegisterDto)
        {
            var customerToRegister = _authService.Register(customerForRegisterDto, customerForRegisterDto.Password);
            if (!customerToRegister.Success)
            {
                return BadRequest(customerToRegister.Message);
            }
            return Ok(customerToRegister.Message);
        }
    }
}
