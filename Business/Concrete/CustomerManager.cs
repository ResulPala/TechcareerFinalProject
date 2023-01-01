using Business.Abstract;
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

        public IResult Add(CreateCustomerDto customer)
        {

            var xx = new Customer();
            xx.FirstName = customer.First_name;
            xx.LastName= customer.Last_name;
            xx.IdentityNumber= customer.Identity_number;
            xx.CustomerNumber = customer.Customer_number;

            _customerDal.Add(xx);
            return new SuccessResult(Messages.Success);

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

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.GetById(x=>x.Id==id));
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
    }
}
