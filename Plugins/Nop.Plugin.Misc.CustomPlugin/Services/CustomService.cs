using Nop.Core.Caching;
using Nop.Data;
using Nop.Plugin.Misc.CustomPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.CustomPlugin.Services
{
    public class CustomService : ICustomService
    {
        private readonly IRepository<ConfigureModel> _configRepository;

        public CustomService(IRepository<ConfigureModel> configRepository,
            IStaticCacheManager staticCacheManager)
        {
            _configRepository = configRepository;
        }

        public async Task<ConfigureModel> GetByIdAsync(int id)
        {
            return await _configRepository.GetByIdAsync(id);
        }

        public async Task UpdateModelAsync(ConfigureModel model)
        {
            await _configRepository.UpdateAsync(model, false);
        }
    }
}
