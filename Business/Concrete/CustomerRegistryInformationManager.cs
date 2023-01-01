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
    public class CustomerRegistryInformationManager : ICustomerRegistryInformationService
    {
        ICustomerRegistryInformationDal _loginInfoDal;
        public CustomerRegistryInformationManager(ICustomerRegistryInformationDal loginInfoDal)
        {
            _loginInfoDal = loginInfoDal;   
        }

        public IResult Add(CreateLoginInfoDto loginInfo)
        {
            var xx = new CustomerRegistryInformation();
            xx.CustomerId = loginInfo.CustomerId;   
                

            _loginInfoDal.Add(xx);
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(DeleteLoginInfoDto loginInfo)
        {
            var xx = new CustomerRegistryInformation();
            xx.Id = loginInfo.Id;
            _loginInfoDal.Delete(xx);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CustomerRegistryInformation>> GetAll()
        {
            return new SuccessDataResult<List<CustomerRegistryInformation>>(_loginInfoDal.GetAll(),Messages.Success);
        }

        public IDataResult<CustomerRegistryInformation> GetById(int id)
        {
            return new SuccessDataResult<CustomerRegistryInformation>(_loginInfoDal.GetById(x=> x.Id==id));
        }

        public IResult Update(UpdateLoginInfoDto loginInfo)
        {
            var xx =new CustomerRegistryInformation();
            xx.Id = loginInfo.Id;
            xx.CustomerId = loginInfo.CustomerId;
            

            _loginInfoDal.Update(xx);
            return new SuccessResult(Messages.Success);
        }
    }
}
