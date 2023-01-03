using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CustomerRegistryInformationDtos
{
    public class CustomerForLoginDto
    {
        public int CustomerNumber { get; set; }
        public string Password { get; set; }
    }
}
