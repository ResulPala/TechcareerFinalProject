using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.AddressDtos
{
    public class UpdateAddressDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address_detail { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }
    }
}
