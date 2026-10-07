using AcadmyCourses.IDentity.Application.Contracts.Repositories;
using AcadmyCourses.IDentity.Application.Contracts.Servicees;
using AcadmyCourses.IDentity.Domain.contracts;
using AcadmyCourses.IDentity.Inftustucture.IDentityContext;
using AcadmyCourses.IDentity.Inftustucture.JWT;
using AcadmyCourses.IDentity.Inftustucture.Profiles;
using AcadmyCourses.IDentity.Inftustucture.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Inftustucture
{
    public static class ServiceInfrustureRegisteration
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<IDentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUniteOfWork, UniteOfWork>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IJwtCreator, JwtCreator>();
            services.AddScoped<IUserGroupRepository, UerGroupRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddAutoMapper(option => option.AddProfile(new UserGroupProfiel()),typeof(UserGroupProfiel).Assembly);
            services.AddAutoMapper(option => option.AddProfile(new PermissionProfile()), typeof(PermissionProfile).Assembly);
            services.AddIdentityCore<Entities.UserEntity>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IDentityDbContext>();
            var jwtSettings = configuration
                                             .GetSection("JwtSettings")
                                             .Get<JwtSettings>()
                                             ?? throw new InvalidOperationException("JWT Settings are missing.");
            services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Key)),
                    ClockSkew = TimeSpan.Zero
                };
            });
            return services;
        }
    }
}
