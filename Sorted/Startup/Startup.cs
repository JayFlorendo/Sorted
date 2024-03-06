using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Sorted.Interface;
using Sorted.Service;

namespace Sorted.Startup
{
    public static class Startup
    {
        public static void ScopedStartup(ref IServiceCollection services, IConfiguration Configuration)
        {

            
            services.AddScoped(typeof(IRainfallService), typeof(RainfallService));


        }

        public static void SingletonStartup(ref IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSingleton(typeof(IRainfallService), typeof(RainfallService));

        }
    }
}
