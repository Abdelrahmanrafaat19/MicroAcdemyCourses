
using AcadmyCourses.IDentity.Api.ExtentionFile;
using AcadmyCourses.IDentity.Application;
using AcadmyCourses.IDentity.Inftustucture;
using AcadmyCourses.IDentity.Inftustucture.JWT;
using Microsoft.OpenApi;

namespace AcadmyCourses.IDentity.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices();
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter your JWT token like: Bearer {your token}"
                });

                options.AddSecurityRequirement(document =>
                 new OpenApiSecurityRequirement
                 {
                     [new OpenApiSecuritySchemeReference("Bearer", document)] =
                         new List<string>()
                 });
            });

            var app = builder.Build();
           await app.SeedDatabaseAsync();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
