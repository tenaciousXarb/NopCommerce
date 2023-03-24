using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.Misc.CustomPlugin.Services;

namespace Nop.Plugin.Misc.CustomPlugin.Infrastructure
{
    public class NopStartup : INopStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomService, CustomService>();
        }

        public void Configure(IApplicationBuilder application)
        {
        }
        public int Order => 3000;
    }
}
