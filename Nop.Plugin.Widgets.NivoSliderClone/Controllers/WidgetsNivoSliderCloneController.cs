using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.NivoSliderClone.Domain;
using Nop.Plugin.Widgets.NivoSliderClone.Models;
using Nop.Plugin.Widgets.NivoSliderClone.Services;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.NivoSliderClone.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class WidgetsNivoSliderCloneController : BasePluginController
    {
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IImageService _imageService;

        public WidgetsNivoSliderCloneController(ILocalizationService localizationService, INotificationService notificationService, IPermissionService permissionService, IImageService imageService)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _imageService = imageService;
        }

        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
            {
                return AccessDeniedView();
            }

            var images = (await _imageService.GetAllImageAsync()).ToList();

#pragma warning disable CS8601 // Possible null reference assignment.
            var model = new ConfigurationModel
            {
                Picture1Id = images[0].MetaData != null ? images[0].Id : 0,
                Picture1Url = await _imageService.GetPictureUrlAsync(images[0].Id),
                Text1 = images[0].Comment,
                Link1 = images[0].Url,
                Picture2Id = images[1].MetaData != null ? images[1].Id : 0,
                Picture2Url = await _imageService.GetPictureUrlAsync(images[1].Id),
                Text2 = images[1].Comment,
                Link2 = images[1].Url,
                Picture3Id = images[2].MetaData != null ? images[2].Id : 0,
                Picture3Url = await _imageService.GetPictureUrlAsync(images[2].Id),
                Text3 = images[2].Comment,
                Link3 = images[2].Url,
                Picture4Id = images[3].MetaData != null ? images[3].Id : 0,
                Picture4Url = await _imageService.GetPictureUrlAsync(images[3].Id),
                Text4 = images[3].Comment,
                Link4 = images[3].Url,
                Picture5Id = images[4].MetaData != null ? images[4].Id : 0,
                Picture5Url = await _imageService.GetPictureUrlAsync(images[4].Id),
                Text5 = images[4].Comment,
                Link5 = images[4].Url
			};
#pragma warning restore CS8601 // Possible null reference assignment.


            return View("~/Plugins/Widgets.NivoSliderClone/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
            {
                return AccessDeniedView();
            }
            var images = (await _imageService.GetAllImageAsync()).ToList();

            if(model.File1 != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.File1.CopyToAsync(memoryStream);
                    images[0].MetaData = memoryStream.ToArray();
                    images[0].Extension = model.File1.ContentType;
                    images[0].FileName = Path.GetFileNameWithoutExtension(model.File1.FileName);
                }
            }
            if (model.File2 != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.File2.CopyToAsync(memoryStream);
                    images[1].MetaData = memoryStream.ToArray();
                    images[1].Extension = model.File2.ContentType;
                    images[1].FileName = Path.GetFileNameWithoutExtension(model.File2.FileName);
                }
            }
            if (model.File3 != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.File3.CopyToAsync(memoryStream);
                    images[2].MetaData = memoryStream.ToArray();
                    images[2].Extension = model.File3.ContentType;
                    images[2].FileName = Path.GetFileNameWithoutExtension(model.File3.FileName);
                }
            }
            if (model.File4 != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.File4.CopyToAsync(memoryStream);
                    images[3].MetaData = memoryStream.ToArray();
                    images[3].Extension = model.File4.ContentType;
                    images[3].FileName = Path.GetFileNameWithoutExtension(model.File4.FileName);

                }
            }
            if (model.File5 != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.File5.CopyToAsync(memoryStream);
                    images[4].MetaData = memoryStream.ToArray();
                    images[4].Extension = model.File5.ContentType;
                    images[4].FileName = Path.GetFileNameWithoutExtension(model.File5.FileName);
                }
            }

            images[0].Comment = model.Text1;
            images[0].Url = model.Link1;

            images[1].Comment = model.Text2;
            images[1].Url = model.Link2;

            images[2].Comment = model.Text3;
            images[2].Url = model.Link3;

            images[3].Comment = model.Text4;
            images[3].Url = model.Link4;

            images[4].Comment = model.Text5;
            images[4].Url = model.Link5;

            foreach(var image in images)
            {
                await _imageService.UpdateImageAsync(image);
            }

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

            return await Configure();
        }
    }
}
