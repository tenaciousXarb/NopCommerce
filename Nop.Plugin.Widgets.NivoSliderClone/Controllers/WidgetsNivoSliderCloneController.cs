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
                Text1 = images[0].Comment,
                Link1 = images[0].Url,
                AltText1 = images[0].Extension,
                Picture2Id = images[1].MetaData != null ? images[1].Id : 0,
                Text2 = images[1].Comment,
                Link2 = images[1].Url,
                AltText2 = images[1].Extension,
                Picture3Id = images[2].MetaData != null ? images[2].Id : 0,
                Text3 = images[2].Comment,
                Link3 = images[2].Url,
                AltText3 = images[2].Extension,
                Picture4Id = images[3].MetaData != null ? images[3].Id : 0,
                Text4 = images[3].Comment,
                Link4 = images[3].Url,
                AltText4 = images[3].Extension,
                Picture5Id = images[4].MetaData != null ? images[4].Id : 0,
                Text5 = images[4].Comment,
                Link5 = images[4].Url,
                AltText5 = images[4].Extension
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

            int[] previousPictureIds = images.Select(x => x.Id).ToArray();
            var currentPictureIds = new[]
            {
                model.Picture1Id,
                model.Picture2Id,
                model.Picture3Id,
                model.Picture4Id,
                model.Picture5Id
            };

            images[0].Id = model.Picture1Id;
            images[0].Comment = model.Text1;
            images[0].Url = model.Link1;
            images[0].Extension = model.AltText1;

            images[1].Id = model.Picture2Id;
            images[1].Comment = model.Text2;
            images[1].Url = model.Link2;
            images[1].Extension = model.AltText2;

            images[2].Id = model.Picture3Id;
            images[2].Comment = model.Text3;
            images[2].Url = model.Link3;
            images[2].Extension = model.AltText3;

            images[3].Id = model.Picture4Id;
            images[3].Comment = model.Text4;
            images[3].Url = model.Link4;
            images[3].Extension = model.AltText4;

            images[4].Id = model.Picture5Id;
            images[4].Comment = model.Text5;
            images[4].Url = model.Link5;
            images[4].Extension = model.AltText5;

            foreach(var image in images)
            {
                await _imageService.UpdateImageAsync(image);
            }

            //delete an old picture (if deleted or updated)
            /*foreach (var pictureId in previousPictureIds.Except(currentPictureIds))
            {
                var previousPicture = await _pictureService.GetPictureByIdAsync(pictureId);
                if (previousPicture != null)
                {
                    await _pictureService.DeletePictureAsync(previousPicture);
                }
            }*/

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

            return await Configure();
        }
    }
}
