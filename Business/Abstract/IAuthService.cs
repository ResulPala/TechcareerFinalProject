using Business.Utilities.Results;
using Business.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs.CustomerRegistryInformationDtos;
using Entities.DTOs.LoginInfoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IResult Register(CustomerForRegisterDto customerForRegisterDto, string password);
        IDataResult<CustomerRegistryInformation> Login(CustomerForLoginDto customerForLoginDto);
        IDataResult<AccessToken> CreateAccessToken(CustomerRegistryInformation customerRegistryInformation);
    }
}
