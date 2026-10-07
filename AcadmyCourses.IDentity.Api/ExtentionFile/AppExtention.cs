using AcadmyCourses.IDentity.Inftustucture.Entities.SeedData;
using AcadmyCourses.IDentity.Inftustucture.IDentityContext;
using Microsoft.EntityFrameworkCore;

namespace AcadmyCourses.IDentity.Api.ExtentionFile
{
    public static class ApplicationExtensions
    {
        public static async Task<WebApplication> SeedDatabaseAsync(
            this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider
                .GetRequiredService<IDentityDbContext>();

            // Apply pending migrations
            await context.Database.MigrateAsync();

            // Seed Permissions
            await PermissionsSeeder.SeedAsync(context);

            return app;
        }
    }
}
