using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Application.Dtos.UserGroupDtos
{
    public class PermissionAddToGroups
    {
        public List<string> ExistedPermissons { get; set; } = [];
        public List<string> NotExistedPermissons { get; set; } = [];
    }
}
