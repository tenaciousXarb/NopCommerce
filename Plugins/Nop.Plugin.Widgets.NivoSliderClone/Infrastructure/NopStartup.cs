using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.Widgets.NivoSliderClone.Services;

namespace Nop.Plugin.Widgets.NivoSliderClone.Infrastructure
{
    public class NopStartup : INopStartup
    {
        public int Order => 3000;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IImageService, ImageService>();
        }

        public void Configure(IApplicationBuilder application)
        {
        }
    }
}
