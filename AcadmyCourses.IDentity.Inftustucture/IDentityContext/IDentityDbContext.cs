


using AcadmyCourses.IDentity.Inftustucture.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AcadmyCourses.IDentity.Inftustucture.IDentityContext
{
    public class IDentityDbContext : IdentityDbContext<UserEntity>
    {
        public IDentityDbContext(DbContextOptions<IDentityDbContext> options):base (options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>()
              .Property(x => x.isActive)
              .HasDefaultValue(true);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IDentityDbContext).Assembly);
        }
    }
}
