using AcadmyCourses.IDentity.Domain.UserGroup;
using AcadmyCourses.IDentity.Inftustucture.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Inftustucture.Cofiguration
{
    public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            //lkshdlkjfhjksdjfkj;sduk;g
            //builder.HasMany(x => x.Users).WithOne(x => x.UserGroup).HasForeignKey(x => x.UserGroupID);
        }
    }
}
