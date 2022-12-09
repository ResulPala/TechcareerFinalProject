﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.LoginInfoDtos
{
    public class UpdateLoginInfoDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Password { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
