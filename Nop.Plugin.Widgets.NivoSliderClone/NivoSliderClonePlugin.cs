using Nop.Core.Infrastructure;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;
using Nop.Plugin.Widgets.NivoSliderClone.Services;
using Nop.Plugin.Widgets.NivoSliderClone.Domain;
using Org.BouncyCastle.Utilities;
using System.Text;

namespace Nop.Plugin.Widgets.NivoSliderClone
{
    public class NivoSliderClonePlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly INopFileProvider _fileProvider;
        private readonly IImageService _imageService;

        public NivoSliderClonePlugin(ILocalizationService localizationService, IPictureService pictureService, ISettingService settingService, IWebHelper webHelper, INopFileProvider fileProvider, IImageService imageService)
        {
            _localizationService = localizationService;
            _pictureService = pictureService;
            _settingService = settingService;
            _webHelper = webHelper;
            _fileProvider = fileProvider;
            _imageService = imageService;

		}
        public override async Task InstallAsync()
        {
            var sampleImagesPath = _fileProvider.MapPath("~/Plugins/Widgets.NivoSliderClone/Content/nivosliderclone/sample-images/");

            var bytes1 = await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "banner1.jpg"));

            var image1 = new ImageModel()
            {
                MetaData = bytes1 ?? null,
                Extension = MimeTypes.ImageJpeg,
                Comment = "",
                Url = _webHelper.GetStoreLocation(),
                FileName = "banner1"
            };
            
            var bytes2 = await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "banner2.jpg"));
            var image2 = new ImageModel()
            {
                MetaData = bytes2 ?? null,
                Extension = MimeTypes.ImageJpeg,
                Comment = "",
                Url = _webHelper.GetStoreLocation(),
                FileName = "banner2",
            };

            await _imageService.InsertImageAsync(image1);
            await _imageService.InsertImageAsync(image2);
            await _imageService.InsertImageAsync(new ImageModel());
            await _imageService.InsertImageAsync(new ImageModel());
            await _imageService.InsertImageAsync(new ImageModel());

            await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Plugins.Widgets.NivoSliderClone.Picture1"] = "Picture 1",
                ["Plugins.Widgets.NivoSliderClone.Picture2"] = "Picture 2",
                ["Plugins.Widgets.NivoSliderClone.Picture3"] = "Picture 3",
                ["Plugins.Widgets.NivoSliderClone.Picture4"] = "Picture 4",
                ["Plugins.Widgets.NivoSliderClone.Picture5"] = "Picture 5",
                ["Plugins.Widgets.NivoSliderClone.Picture"] = "Picture",
                ["Plugins.Widgets.NivoSliderClone.Picture.Hint"] = "Upload picture.",
                ["Plugins.Widgets.NivoSliderClone.Text"] = "Comment",
                ["Plugins.Widgets.NivoSliderClone.Text.Hint"] = "Enter comment for picture. Leave empty if you don't want to display any text.",
                ["Plugins.Widgets.NivoSliderClone.Link"] = "URL",
                ["Plugins.Widgets.NivoSliderClone.Link.Hint"] = "Enter URL. Leave empty if you don't want this picture to be clickable.",
                ["Plugins.Widgets.NivoSliderClone.AltText"] = "Image alternate text",
                ["Plugins.Widgets.NivoSliderClone.AltText.Hint"] = "Enter alternate text that will be added to image."
            });

            await base.InstallAsync();
        }


        public override async Task UninstallAsync()
        {
            var images = await _imageService.GetAllImageAsync();
            await _imageService.DeleteAllImageAsync(images);

            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.NivoSliderClone");
            
            await base.UninstallAsync();
        }

        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsNivoSliderClone/Configure";
        }

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsNivoSliderClone";
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageTop });
        }
        public bool HideInWidgetList => false;
    }
}