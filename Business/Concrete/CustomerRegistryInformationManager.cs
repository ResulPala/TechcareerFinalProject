using Business.Abstract;
using Business.Utilities;
using Business.Utilities.Constant.Messages;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CustomerRegistryInformationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerRegistryInformationManager : ICustomerRegistryInformationService
    {
        ICustomerRegistryInformationDal _customerRegistryInformationDal;
        ICustomerService _customerService;

        public CustomerRegistryInformationManager(ICustomerRegistryInformationDal customerRegistryInformationDal, ICustomerService customerService)
        {
            _customerRegistryInformationDal = customerRegistryInformationDal;
            _customerService = customerService;
        }

        public IDataResult<List<CustomerRegistryInformation>> GetAll()
        {
            return new SuccessDataResult<List<CustomerRegistryInformation>>(_customerRegistryInformationDal.GetAll());
        }

        public IDataResult<CustomerRegistryInformation> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<CustomerRegistryInformation>(_customerRegistryInformationDal.Get(r => r.CustomerId == customerId));
        }

        public IResult Add(CustomerRegistryInformation customerRegistryInformation)
        {
            var result = BusinessRules.Run(
                CheckIfCustomerNotExistWithCustomerId(customerRegistryInformation.CustomerId), //bu method olmadan kendisi nasil bir hata verir?
                CheckIfCustomerAlreadyRegistered(customerRegistryInformation.CustomerId)
                );
            _customerRegistryInformationDal.Add(customerRegistryInformation);
            return new SuccessResult(Messages.Success);
        }

        public List<OperationClaim> GetOperationClaims(CustomerRegistryInformation customerRegistryInformation)
        {
            return _customerRegistryInformationDal.GetClaims(customerRegistryInformation);
        }

        //BUSINESS CODES

        private IResult CheckIfCustomerNotExistWithCustomerId(int customerId)
        {
            var customerExistence = _customerService.GetById(customerId);
            if (customerExistence == null)
            {
                return new ErrorResult(Messages.CustomerNotExistError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCustomerAlreadyRegistered(int customerId)
        {
            var result = _customerRegistryInformationDal.GetAll(c => c.CustomerId == customerId).Any();
            if (result)
            {
                return new ErrorResult(Messages.CustomerAlreadyRegisteredError);
            };
            return new SuccessResult();
        }

        
    }
}
