using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.AccountDtos;
using Entities.DTOs.AddressDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]es")]
    [ApiController]
    public class CustomerContactInformationController : ControllerBase
    {
        ICustomerContactInformationService _addressService;
        public CustomerContactInformationController(ICustomerContactInformationService addressService)
        {
            _addressService = addressService;
        }
        [HttpPost]
        public IActionResult Add([FromQuery] CreateAddressDto address)
        {
         
            var result = _addressService.Add(address);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromQuery] UpdateAddressDto address)
        {
            var result = _addressService.Update(address);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] DeleteAddressDto address)
        {
            var result = _addressService.Delete(address);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _addressService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var result = _addressService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
