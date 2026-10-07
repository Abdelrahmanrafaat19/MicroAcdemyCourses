using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Inftustucture.Entities
{
    public class Permission
    {
        public Guid Id { get; set; }
        public string Code { get; set; } =default!;

        public string Name { get; set; } = default!;
        public string Module { get; set; } = default!;
        public ICollection<GroupPermission> UserGroupPermissions { get; set; } =new List<GroupPermission>();
    }
}
