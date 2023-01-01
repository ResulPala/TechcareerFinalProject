using Business.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.AccountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerAccountService
    {
        IDataResult<CustomerAccount> GetById(int id);
        IDataResult<List<CustomerAccount>> GetAll();
        IResult Add(CreateAccountDto account);
        IResult Update(UpdateAccountDto account);
        IResult Delete(DeleteAccountDto account);
    }
}
