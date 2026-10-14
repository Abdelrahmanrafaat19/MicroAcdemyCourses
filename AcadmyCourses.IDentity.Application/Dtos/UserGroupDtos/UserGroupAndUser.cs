using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Application.Dtos.UserGroupDtos
{
    public class UserGroupAndUser
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<UserEntityDto> Users { get; set; } = [];
    }
}
