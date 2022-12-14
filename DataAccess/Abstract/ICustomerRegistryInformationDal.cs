using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICustomerRegistryInformationDal : IEntityRepository<CustomerRegistryInformation>
    {
        List<OperationClaim> GetClaims(CustomerRegistryInformation customerRegistryInformation);
    }
}
