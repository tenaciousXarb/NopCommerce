using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Nop.Core.Caching;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.NivoSliderClone.Domain;
using Nop.Plugin.Widgets.NivoSliderClone.Services;
using Nop.Plugin.Widgets.NivoSliderClone.Models;
using NUglify.JavaScript.Syntax;

namespace Nop.Plugin.Widgets.NivoSliderClone.Components
{
    [ViewComponent(Name = "WidgetsNivoSliderClone")]
    public class WidgetsNivoSliderCloneViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;
        private readonly IWebHelper _webHelper;
        private readonly IImageService _imageService;

        public WidgetsNivoSliderCloneViewComponent(IStoreContext storeContext, IStaticCacheManager staticCacheManager, ISettingService settingService, IPictureService pictureService, IWebHelper webHelper, IImageService imageService)
        {
            _storeContext = storeContext;
            _staticCacheManager = staticCacheManager;
            _settingService = settingService;
            _pictureService = pictureService;
            _webHelper = webHelper;
            _imageService = imageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            var model = await _imageService.GetAllImageAsync();
            var publicInfoList = new List<PublicInfoModel>();

            foreach (var image in model)
            {
                publicInfoList.Add(new PublicInfoModel()
                {
                    PictureUrl = image.MetaData != null ? await _imageService.GetPictureUrlAsync(image.Id) : string.Empty,
                    Url = image.Url,
                    Comment = image.Comment,
                    Extension = image.Extension
                });
            }

            if (!publicInfoList.Where(x => x.PictureUrl != null).ToList().Any())
            {
                return Content("");
            }
            else
            {
                return View("~/Plugins/Widgets.NivoSliderClone/Views/PublicInfo.cshtml", publicInfoList);
            }
        }
    }
}