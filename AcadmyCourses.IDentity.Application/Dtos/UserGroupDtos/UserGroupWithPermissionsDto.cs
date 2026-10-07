// using the fully-qualified type name for PermissionDto to avoid namespace/type name collision
using System;
using System.Collections.Generic;

namespace AcadmyCourses.IDentity.Application.Dtos.UserGroupDtos
{
    public class UserGroupWithPermissionsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public List<AcadmyCourses.IDentity.Application.Dtos.PermissionDto.PermissionDto> Permissions { get; set; } = new List<AcadmyCourses.IDentity.Application.Dtos.PermissionDto.PermissionDto>();
    }
}
