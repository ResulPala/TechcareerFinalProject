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

        public IDataResult<CustomerRegistryInformation> Register(CustomerForRegisterDto customerForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var customer = CheckIfCustomerExist(customerForRegisterDto.CustomerNumber);
            if (!customer.Success)
            {
                return new ErrorDataResult<CustomerRegistryInformation>(Messages.CustomerAlreadyExistError);
            }
            var customerId = customer.Data.Id; //hatayi runtimeda burda firlatiyor
            var customerRegistryInformation = new CustomerRegistryInformation
            {
                CustomerId = customerId,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            _customerRegistryInformationService.Add(customerRegistryInformation);
            return new SuccessDataResult<CustomerRegistryInformation>(customerRegistryInformation, Messages.CustomerRegistered);
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
            return new SuccessDataResult<CustomerRegistryInformation>(Messages.LoginSuccessfully);
            
            
        }

        public IDataResult<AccessToken> CreateAccessToken(CustomerRegistryInformation customerRegistryInformation)
        {
            var claims = _customerRegistryInformationService.GetOperationClaims(customerRegistryInformation);
            var accessToken = _tokenHelper.CreateToken(customerRegistryInformation, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        


        //BUSINESS CODES

        private IDataResult<Customer> CheckIfCustomerExist(int customerNumber)
        {
            var customer = _customerService.GetByCustomerNumber(customerNumber);
            if (customer == null)
            {
                return new ErrorDataResult<Customer>(Messages.CustomerNotExistError);
            }
            return new SuccessDataResult<Customer>(customer.Data);
        }

        
    }
}
