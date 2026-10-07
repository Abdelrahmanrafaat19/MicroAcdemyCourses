using AcadmyCourses.IDentity.Inftustucture.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Domain.UserGroup
{
    public class UserGroup
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; }
        public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
        public ICollection<GroupPermission> UserGroupPermissions { get; set; } = new List<GroupPermission>();


    }
}
