using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Application.Dtos.CreateUserDto
{
    public class ReturnedUserCreation
    {
        public string fullName  { get; set; } = default!;
        public string Token { get; set; } = default!;
        public string userName { get; set; } = default!;
        public string email { get; set; } = default!;
    }
}
