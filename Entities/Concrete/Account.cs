using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int Balance { get; set; }
        public DateTime OpenTime{ get; set; } = DateTime.Now;
        public DateTime ClosedTime { get; set; }
        public int Account_type { get; set; }
    }
}
