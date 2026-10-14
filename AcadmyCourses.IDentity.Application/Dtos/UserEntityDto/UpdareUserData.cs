using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Application.Dtos.UserEntityDto
{
    public class UpdateUserData
    {
  
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 

        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? CurrentPassword { get; set; }
    }
}
