using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.AccountDtos
{
    public class UpdateAccountDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Account_type { get; set; }
    }
}
