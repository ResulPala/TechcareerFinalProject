using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CustomerAccount : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AccountType { get; set; }
        public string AccountNumber { get; set; }
        public int Balance { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public Customer Customer { get; set; }
    }
}
