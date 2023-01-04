using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public OperationClaim()
        {
            CustomerOperationClaims = new HashSet<CustomerOperationClaim>();
        }
        public int Id { get; set; }
        public string Claim { get; set; }
        public ICollection<CustomerOperationClaim> CustomerOperationClaims { get; set; }    
    }
}
