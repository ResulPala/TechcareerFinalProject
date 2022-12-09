using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class LoginInfo : IEntity
    {
        public int Id{ get; set; }
        public int CustomerId { get; set; }
        public Customer Customer{ get; set; }
        public string Password { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
