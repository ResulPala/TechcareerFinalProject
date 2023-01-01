using Business.Abstract;
using Business.Utilities.Constant.Messages;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.AccountDtos;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerAccountManager : ICustomerAccountService
    {
        ICustomerAccountDal _accountDal;
        public CustomerAccountManager(ICustomerAccountDal accountDal)
        {
            _accountDal = accountDal;
        }
    
        public IResult Add(CreateAccountDto account)
        {
            var xx = new CustomerAccount();
            xx.CustomerId = account.CustomerId;
            xx.Balance = 0;
            xx.OpenTime = DateTime.Now;
            //xx.ClosedTime = DateTime.Now;
            xx.AccountType = account.Account_type;

            _accountDal.Add(xx);    
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(DeleteAccountDto account)
        {
            var xx = new CustomerAccount();
            xx.Id = account.Id;
            _accountDal.Delete(xx);
            return new SuccessResult(Messages.Deleted);

        }

        public IDataResult<List<CustomerAccount>> GetAll()
        {
            return new SuccessDataResult<List<CustomerAccount>>(_accountDal.GetAll(),Messages.Success);
        }

        public IDataResult<CustomerAccount> GetById(int id)
        {
            return new SuccessDataResult<CustomerAccount>(_accountDal.GetById(x=>x.Id==id),Messages.Success);
        }

        public IResult Update(UpdateAccountDto account)
        {
            var xx = new CustomerAccount();
            xx.Id = account.Id;
            xx.CustomerId = account.CustomerId;
            xx.AccountType = account.Account_type;
            _accountDal.Update(xx);
            return new SuccessResult(Messages.Success);
        }

        
        
    }

    
}
