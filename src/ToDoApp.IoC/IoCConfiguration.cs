using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace ToDoApp.IoC
{
    public static class IoCConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            Configure(services, Data.IoC.Module.GetTypes());
            Configure(services, DomainServices.IoC.Module.GetTypes());
            Configure(services, AppServices.IoC.Module.GetTypes());
        }

        private static void Configure(IServiceCollection service, Dictionary<Type,Type> types)
        {
            foreach (var type in types)
                service.AddScoped(type.Key, type.Value);
        }
    }
}
