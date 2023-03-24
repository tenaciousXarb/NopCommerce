using Nop.Core;
using Nop.Plugin.Misc.CustomPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.CustomPlugin.Services
{
    public interface ICustomService
    {
        Task<ConfigureModel> GetByIdAsync(int id);

        Task UpdateModelAsync(ConfigureModel model);
    }
}
