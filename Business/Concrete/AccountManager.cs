using Business.Abstract;
using Business.Utilities.Constant.Messages;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.AccountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AccountManager : IAccountService
    {
        IAccountDal _accountDal;
        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }
    
        public IResult Add(CreateAccountDto account)
        {
            var xx = new Account();
            xx.CustomerId = account.CustomerId;
            xx.Balance = 0;
            xx.OpenTime = DateTime.Now;
            //xx.ClosedTime = DateTime.Now;
            xx.Account_type = account.Account_type;

            _accountDal.Add(xx);    
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(DeleteAccountDto account)
        {
            var xx = new Account();
            xx.Id = account.Id;
            _accountDal.Delete(xx);
            return new SuccessResult(Messages.Deleted);

        }

        public IDataResult<List<Account>> GetAll()
        {
            return new SuccessDataResult<List<Account>>(_accountDal.GetAll(),Messages.Success);
        }

        public IDataResult<Account> GetById(int id)
        {
            return new SuccessDataResult<Account>(_accountDal.GetById(x=>x.Id==id),Messages.Success);
        }

        public IResult Update(UpdateAccountDto account)
        {
            var xx = new Account();
            xx.Id = account.Id;
            xx.CustomerId = account.CustomerId;
            xx.Account_type = account.Account_type;
            _accountDal.Update(xx);
            return new SuccessResult(Messages.Success);
        }
    }
}
