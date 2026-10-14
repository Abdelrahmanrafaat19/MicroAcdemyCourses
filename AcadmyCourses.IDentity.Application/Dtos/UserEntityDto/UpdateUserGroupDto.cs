
using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Application.Dtos.UserEntityDto
{
    public class UpdateUserGroupDto
    {
        public required Guid UserID { get; set; } 
        public required Guid GroupID { get; set; }
    }
}
