﻿using System;
using Microsoft.AspNetCore.Builder;
using OrchardCore.Modules;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Security.Permissions;

namespace OrchardCore.Profile
{
    public class Startup : StartupBase
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPermissionProvider, Permissions>();
        }

        public override void Configure(IApplicationBuilder builder, IRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaRoute(
                name: "EndOrchardCore.ProfileWithGroupId",
                areaName: "OrchardCore.Profile",
                template: "Profile/{groupId}",
                defaults: new { controller = "Profile", action = "Index" }
            );

            routes.MapAreaRoute(
                name: "EndOrchardCore.Profile",
                areaName: "OrchardCore.Profile",
                template: "Profile",
                defaults: new { controller = "Profile", action = "Index" }
            );
        }
    }
}
