using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Application.Dtos.CreateUserDto
{
    public class CreateUserDto
    {
        public string firstName { get; set; } = default!;
        public string lastName { get; set; } = default!;
        public string userName { get; set; } = default!;
        public string email { get; set; } = default!;
        public string password { get; set; } = default!;
    }
}
