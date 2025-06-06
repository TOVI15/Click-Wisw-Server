﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Identity { get; set; } = string.Empty;

        public string? Password { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Role { get; set; } = string.Empty;

    }
}
