using AcadmyCourses.IDentity.Inftustucture.IDentityContext;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AcadmyCourses.IDentity.Inftustucture.Entities.SeedData
{
    public class PermissionsSeeder
    {
        public static async Task SeedAsync(
      IDentityDbContext context,
      CancellationToken cancellationToken = default)
        {
            var filePath = Path.Combine(
                AppContext.BaseDirectory,
                "Entities",
                "SeedData",
                "permissions.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(
                    $"Permission seed file was not found: {filePath}");
            }

            var json = await File.ReadAllTextAsync(
                filePath,
                cancellationToken);

            var permissions =
                JsonSerializer.Deserialize<List<Permission>>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            if (permissions == null || permissions.Count == 0)
                return;

            foreach (var item in permissions)
            {
                var exists = await context.Permissions.AsNoTracking()
                    .AnyAsync(
                        x => x.Code == item.Code,
                        cancellationToken);

                if (exists)
                    continue;

                var permission = new Permission
                {
                    Id = Guid.NewGuid(),
                    Code = item.Code,
                    Name = item.Name,
                    Module = item.Module
                };

                await context.Permissions.AddAsync(
                    permission,
                    cancellationToken);
            }

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
