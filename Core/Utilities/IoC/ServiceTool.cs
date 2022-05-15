using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services) // .net servislerini al ve onları build et demek
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
        // bu kod bizim webapı de veya autofac de oluşturduğumuz injectionları oluşturabilmemize yarıyo
    }
}
