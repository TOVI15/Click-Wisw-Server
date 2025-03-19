using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.Entities
{
    public class StudentBasicInfo
    {
        public int Id { get; set; }  // מפתח ראשי
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string KohenLeviIsrael { get; set; } = string.Empty;  // כהן/לוי/ישראל
        public string IdentityNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Phone { get; set; }= string.Empty;
        public string CountryOfBirth { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime HebrewDateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        public StudentDetails AdditionalInfo { get; set; }
        public ICollection<Documents> Documents { get; set; } = new List<Documents>();    
    }
}
