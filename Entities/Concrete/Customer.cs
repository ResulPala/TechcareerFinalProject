using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public Customer()
        {
            CustomerAccounts = new HashSet<CustomerAccount>();
            CustomerContactInformations = new HashSet<CustomerContactInformation>();
            CustomerRegistryInformations = new HashSet<CustomerRegistryInformation>();
            CustomerOperationClaims = new HashSet<CustomerOperationClaim>();
        }
        public int Id { get; set; }
        public long IdentityNumber { get; set; }
        public int CustomerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<CustomerAccount> CustomerAccounts { get; set; }
        public ICollection<CustomerContactInformation> CustomerContactInformations { get; set; }
        public ICollection<CustomerRegistryInformation> CustomerRegistryInformations { get; set; }
        public ICollection<CustomerOperationClaim> CustomerOperationClaims { get; set; }

    }
}
