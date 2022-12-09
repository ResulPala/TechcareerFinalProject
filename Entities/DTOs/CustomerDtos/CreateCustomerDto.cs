using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CustomerDtos
{
    public class CreateCustomerDto
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public int Identity_number { get; set; }
        public int Customer_number { get; set; }
    }
}
