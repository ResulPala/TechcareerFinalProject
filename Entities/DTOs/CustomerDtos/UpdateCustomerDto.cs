using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CustomerDtos
{
    public class UpdateCustomerDto
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public int Identity_number { get; set; }
    }
}
