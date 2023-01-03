using Business.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.CustomerRegistryInformationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerRegistryInformationService
    {
        IDataResult<List<CustomerRegistryInformation>> GetAll();
        IDataResult<CustomerRegistryInformation> GetByCustomerId(int customerId);
        List<OperationClaim> GetOperationClaims(CustomerRegistryInformation customerRegistryInformation);
        IResult Add(CustomerRegistryInformation customerRegistryInformation);
    }
}
