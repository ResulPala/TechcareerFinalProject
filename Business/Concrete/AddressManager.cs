﻿using Business.Abstract;
using Business.Utilities.Constant.Messages;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.AddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public IResult Add(CreateAddressDto address)
        {
            var xx = new Address();
            xx.CustomerId = address.CustomerId;
            xx.Country = address.Country;   
            xx.City = address.City; 
            xx.Address_detail = address.Address_detail;
            xx.Phone_number = address.Phone_number;
            xx.Email = address.Email;

            _addressDal.Add(xx);
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(DeleteAddressDto address)
        {
            var xx = new Address();
            xx.Id = address.Id;
            _addressDal.Delete(xx);    
            return new SuccessResult(Messages.Success); 
        }

        public IDataResult<List<Address>> GetAll()
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(),Messages.Success);
        }

        public IDataResult<Address> GetById(int id)
        {
            return new SuccessDataResult<Address>(_addressDal.GetById(x=>x.Id == id));
        }

        public IResult Update(UpdateAddressDto address)
        {
            var xx = new Address();
            xx.Id = address.Id;
            xx.CustomerId = address.CustomerId;
            xx.Country = address.Country;
            xx.City=address.City;
            xx.Address_detail = address.Address_detail;
            xx.Phone_number = address.Phone_number;
            xx.Email = address.Email;

            _addressDal.Update(xx);
            return new SuccessResult(Messages.Success);
        }
    }
}