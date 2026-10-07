using AcadmyCourses.IDentity.Domain.UserGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Inftustucture.Entities
{
    public class GroupPermission
    {
        public Guid PermissionId { get; set; }
        public UserGroup UserGroupCo { get; set; } = default!;
        public Guid UserGroupID { get; set; }
        public Permission PermissionCo { get; set; } = default!;

    }
}
