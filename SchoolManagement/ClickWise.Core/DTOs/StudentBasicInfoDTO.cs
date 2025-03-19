using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.DTOs
{
    public class StudentBasicInfoDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string KohenLeviIsrael { get; set; } = string.Empty;
        public string IdentityNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Phone { get; set; }= string.Empty;
        public string CountryOfBirth { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime HebrewDateOfBirth { get; set; }
    }
}
