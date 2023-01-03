using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCustomerRegistryInformationDal : EfEntityRepositoryBase<CustomerRegistryInformation, OnlineBankingContext>, ICustomerRegistryInformationDal
    {
        public List<OperationClaim> GetClaims(CustomerRegistryInformation customerRegistryInformation)
        {
            using (var context = new OnlineBankingContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join customerOperationClaim in context.CustomerOperationClaims
                               on operationClaim.Id equals customerOperationClaim.OperationClaimId
                             where operationClaim.Id == customerRegistryInformation.CustomerId
                             select new OperationClaim { Id = operationClaim.Id, Claim = operationClaim.Claim };
                return result.ToList();
            }
        }
    }
}
