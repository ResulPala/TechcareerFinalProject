using Business.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.LoginInfoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerRegistryInformationService
    {
        IDataResult<CustomerRegistryInformation> GetById(int id);
        IDataResult<List<CustomerRegistryInformation>> GetAll();
        IResult Add(CreateLoginInfoDto loginInfo);
        IResult Update(UpdateLoginInfoDto loginInfo);
        IResult Delete(DeleteLoginInfoDto loginInfo);
    }
}
