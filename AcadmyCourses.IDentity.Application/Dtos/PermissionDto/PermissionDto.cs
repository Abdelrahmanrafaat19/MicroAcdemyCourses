using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Application.Dtos.PermissionDto
{
    public class PermissionDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = default!;

        public string Name { get; set; } = default!;
        public string Module { get; set; } = default!;
    }
}
