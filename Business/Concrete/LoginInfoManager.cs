using Business.Abstract;
using Business.Utilities.Constant.Messages;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.LoginInfoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LoginInfoManager : ILoginInfoService
    {
        ILoginInfoDal _loginInfoDal;
        public LoginInfoManager(ILoginInfoDal loginInfoDal)
        {
            _loginInfoDal = loginInfoDal;   
        }

        public IResult Add(CreateLoginInfoDto loginInfo)
        {
            var xx = new LoginInfo();
            xx.CustomerId = loginInfo.CustomerId;   
            xx.Answer = loginInfo.Answer;
            xx.Question = loginInfo.Question;
            xx.Password= loginInfo.Password;    

            _loginInfoDal.Add(xx);
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(DeleteLoginInfoDto loginInfo)
        {
            var xx = new LoginInfo();
            xx.Id = loginInfo.Id;
            _loginInfoDal.Delete(xx);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<LoginInfo>> GetAll()
        {
            return new SuccessDataResult<List<LoginInfo>>(_loginInfoDal.GetAll(),Messages.Success);
        }

        public IDataResult<LoginInfo> GetById(int id)
        {
            return new SuccessDataResult<LoginInfo>(_loginInfoDal.GetById(x=> x.Id==id));
        }

        public IResult Update(UpdateLoginInfoDto loginInfo)
        {
            var xx =new LoginInfo();
            xx.Id = loginInfo.Id;
            xx.CustomerId = loginInfo.CustomerId;
            xx.Password = loginInfo.Password;
            xx.Question = loginInfo.Question;
            xx.Answer = loginInfo.Answer;

            _loginInfoDal.Update(xx);
            return new SuccessResult(Messages.Success);
        }
    }
}
