﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.DTO
{
    public class RegisterationRequestDTO
    {
        public string Email { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }

    }
}
