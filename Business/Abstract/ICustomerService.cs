using Business.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> GetById(int id);
        IDataResult<List<Customer>> GetAll();
        IResult Add(CreateCustomerDto customer);
        IResult Update(Customer customer);
        IResult Delete(DeleteCustomerDto customer);
    }
}
