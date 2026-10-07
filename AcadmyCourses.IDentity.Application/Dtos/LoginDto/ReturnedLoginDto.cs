using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Application.Dtos.LoginDto
{
    public class ReturnedLoginDto
    {
        public string FullName { get; set; } = default;
        public string Email { get; set; } = default;
        public string Token { get; set; } = default;
    }
}
