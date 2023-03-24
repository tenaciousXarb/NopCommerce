using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Stores;
using Nop.Plugin.Misc.CustomPlugin.Models;
using Nop.Plugin.Misc.CustomPlugin.Services;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Framework.Components;
using Nop.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.CustomPlugin.Components
{
    [ViewComponent(Name = "CustomPlugin")]
    public class WidgetsCustomPluginViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;
        private readonly IWebHelper _webHelper;
        private readonly ICustomService _customService;

        public WidgetsCustomPluginViewComponent(IStoreContext storeContext, IStaticCacheManager staticCacheManager, ISettingService settingService, IPictureService pictureService, IWebHelper webHelper, ICustomService customService)
        {
            _storeContext = storeContext;
            _staticCacheManager = staticCacheManager;
            _settingService = settingService;
            _pictureService = pictureService;
            _webHelper = webHelper;
            _customService = customService;
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            var figure = await _customService.GetByIdAsync(new ConfigModel().Id);

            var model = new InfoModel
            {
                FullName = figure.FullName,
                Email = figure.Email
            };

            if(string.IsNullOrEmpty(model.FullName) && string.IsNullOrEmpty(model.Email))
            {
                return Content("");
            }

            return View("~/Plugins/Misc.CustomPlugin/Views/CustomPublicInfo.cshtml", model);
        }

    }
}
