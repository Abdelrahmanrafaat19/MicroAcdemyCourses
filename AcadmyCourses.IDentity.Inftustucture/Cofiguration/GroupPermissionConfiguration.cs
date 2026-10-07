using AcadmyCourses.IDentity.Inftustucture.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Inftustucture.Cofiguration
{
    public class GroupPermissionConfiguration : IEntityTypeConfiguration<GroupPermission>
    {
        public void Configure(EntityTypeBuilder<GroupPermission> builder)
        {
            builder.HasKey(x => new { x.UserGroupID, x.PermissionId });
            builder.HasOne(x => x.UserGroupCo)
                .WithMany(g => g.UserGroupPermissions)
                .HasForeignKey(x => x.UserGroupID);
            builder.HasOne(x => x.PermissionCo)
               .WithMany(p => p.UserGroupPermissions)
               .HasForeignKey(x => x.PermissionId);
        }
    }
}
