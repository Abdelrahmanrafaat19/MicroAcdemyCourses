using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Application.Dtos.UserGroupDtos
{
    public class UserEntityDto
    {
        public Guid  Id{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool isActive { get; set; } = true;
    }
}
