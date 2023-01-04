using Business.Abstract;
using Business.Utilities;
using Business.Utilities.Constant.Messages;
using Business.Utilities.Results;
using Business.Utilities.Security.Hashing;
using Business.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs.CustomerRegistryInformationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private ICustomerService _customerService;
        private ICustomerRegistryInformationService _customerRegistryInformationService;

        private ITokenHelper _tokenHelper;

        public AuthManager(ICustomerRegistryInformationService customerRegistryInformationService, ITokenHelper tokenHelper, ICustomerService customerService)
        {
            _customerRegistryInformationService = customerRegistryInformationService;
            _tokenHelper = tokenHelper;
            _customerService = customerService;
        }

        public IResult Register(CustomerForRegisterDto customerForRegisterDto, string password)
        {
            var result = BusinessRules.Run(
                CheckIfCustomerExist(customerForRegisterDto.CustomerNumber)
                );

            if (result != null)
            {
                return result;
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var customer = _customerService.GetByCustomerNumber(customerForRegisterDto.CustomerNumber);
            var customerId = customer.Data.Id; //hatayi runtimeda burda firlatiyor
            var customerRegistryInformation = new CustomerRegistryInformation
            {
                CustomerId = customerId,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            return _customerRegistryInformationService.Add(customerRegistryInformation);         
        }

        public IDataResult<CustomerRegistryInformation> Login(CustomerForLoginDto customerForLoginDto)
        {
            var customer = _customerService.GetByCustomerNumber(customerForLoginDto.CustomerNumber);
            var customerToCheck = _customerRegistryInformationService.GetByCustomerId(customer.Data.Id);
            if (customerToCheck == null)
            {
                return new ErrorDataResult<CustomerRegistryInformation>(Messages.CustomerNotExistError);
            }
            if (!HashingHelper.VerifyPasswordHash(customerForLoginDto.Password, customerToCheck.Data.PasswordHash, customerToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<CustomerRegistryInformation>(Messages.PasswordError);
            }
            return new SuccessDataResult<CustomerRegistryInformation>(customerToCheck.Data ,Messages.LoginSuccessfully);
            
            
        }

        public IDataResult<AccessToken> CreateAccessToken(CustomerRegistryInformation customerRegistryInformation)
        {
            var claims = _customerRegistryInformationService.GetOperationClaims(customerRegistryInformation);
            var accessToken = _tokenHelper.CreateToken(customerRegistryInformation, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        


        //BUSINESS CODES

        private IResult CheckIfCustomerExist(int customerNumber)
        {
            var customer = _customerService.GetByCustomerNumber(customerNumber);
            if (customer.Data == null)
            {
                return new ErrorResult(Messages.CustomerNotExistError);
            }
            return new SuccessResult();
        }
        
        

        
    }
}
