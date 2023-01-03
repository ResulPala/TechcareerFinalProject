using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Utilities;
using Business.Utilities.Constant.Messages;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
         ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [SecuredOperation("admin")]
        public IResult Add(CreateCustomerDto createCustomerDto)
        {
            var result = BusinessRules.Run(
                CheckIfCustomerExistWithIdentitynumber(createCustomerDto.IdentityNumber)
                );

            if (result != null)
            {
                return result;
            }

            var customer = new Customer();
            customer.FirstName = createCustomerDto.FirstName;
            customer.LastName= createCustomerDto.LastName;
            customer.IdentityNumber= createCustomerDto.IdentityNumber;
            customer.CustomerNumber = createCustomerDto.CustomerNumber;

            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAddedSuccessfully);

        }

        public IResult Delete(DeleteCustomerDto customer)
        {
            var xx = new Customer();
            xx.Id = customer.Id;
            _customerDal.Delete(xx);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.Success);
        }

        public IDataResult<Customer> GetByCustomerNumber(int customerNumber)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerNumber == customerNumber));
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(x=>x.Id==id));
        }


        public IResult Update(Customer customer)
        {
            if (customer == null)
            {
                return new ErrorResult(Messages.Invalid);
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Success);
        }

        //BUSINESS RULES

        private IResult CheckIfCustomerExistWithIdentitynumber(long identityNumber)
        {
            var identityNumberExistence = _customerDal.GetAll(c => c.IdentityNumber == identityNumber).Any();
            if (identityNumberExistence)
            {
                return new ErrorResult(Messages.CustomerAlreadyExistError);
            }

            return new SuccessResult();
        }

    }
}
