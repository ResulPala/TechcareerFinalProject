using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EmployeeOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int OperationClaimId { get; set; }
        public Employee Employee { get; set; }
        public OperationClaim OperationClaim { get; set; }
    }
}
