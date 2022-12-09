﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }  
        public Customer Customer { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address_detail { get; set; }
        public int Phone_number { get; set; }
        public string Email { get; set; }
    }
}
