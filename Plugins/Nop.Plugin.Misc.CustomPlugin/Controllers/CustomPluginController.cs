using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Misc.CustomPlugin.Models;
using Nop.Plugin.Misc.CustomPlugin.Services;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework.UI.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.CustomPlugin.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class CustomPluginController : BasePluginController
    {
        private readonly IPermissionService _permissionService;
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;
        private readonly ICustomService _customService;

        public CustomPluginController(IPermissionService permissionService, IStoreContext storeContext, ISettingService settingService, ICustomService customService)
        {
            _permissionService = permissionService;
            _storeContext = storeContext;
            _settingService = settingService;
            _customService = customService;
        }

        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            var figure = await _customService.GetByIdAsync(new ConfigModel().Id);

            var model = new ConfigModel
            {
                Id = figure.Id,
                FullName = figure.FullName,
                Email = figure.Email
            };

            return View("~/Plugins/Misc.CustomPlugin/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigureModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
            {
                return AccessDeniedView();
            }
            model.Id = new ConfigModel().Id;
            await _customService.UpdateModelAsync(model);

            return await Configure();
        }
    }
}
