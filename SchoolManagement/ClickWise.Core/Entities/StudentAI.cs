using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.Entities
{
    public class StudentAI
    {
        
            public int Id { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? IdentityNumber { get; set; }
            public string? Phone { get; set; }
            public string? City { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string? HealthInsurance { get; set; }
            public DateTime UpdatedAt { get; set; }
            public DateTime CreatedAt { get; set; }

        // מהפרטים המורחבים
        public string? FatherName { get; set; }
            public string? FatherPhone { get; set; }
            public string? MotherName { get; set; }
            public string? MotherPhone { get; set; }
            public string? YeshivaName { get; set; }
            public string? Note { get; set; }
    }

}

