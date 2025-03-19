using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.DTOs
{
    public class LoginDTO
    {
        public UserDTO User { get; set; }=new UserDTO();
        public string Token { get; set; } = string.Empty;

    }
}
