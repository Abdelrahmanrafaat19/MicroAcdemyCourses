using AcadmyCourses.IDentity.Inftustucture.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Inftustucture.Cofiguration
{
    public class ApplicationUserEntity : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.UserGroupNavigational)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.UserGroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
