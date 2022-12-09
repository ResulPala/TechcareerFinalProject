using Business.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.AddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAddressService
    {
        IDataResult<Address> GetById(int id);
        IDataResult<List<Address>> GetAll();
        IResult Add(CreateAddressDto address);
        IResult Update(UpdateAddressDto address);
        IResult Delete(DeleteAddressDto address);
    }
}
