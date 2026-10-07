using AcadmyCourses.IDentity.Application.Contracts.Servicees;
using AcadmyCourses.IDentity.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Application
{
    public static class ServiceApplicationRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthentictionService, AuthenticationService>();
            services.AddScoped<IUserGroupService, UserGroupService>();
            services.AddScoped<IPermissionServices, PermissionService>();
            return services;
        }
    }
}
