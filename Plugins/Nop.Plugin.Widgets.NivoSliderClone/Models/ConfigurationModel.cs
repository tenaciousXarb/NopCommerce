using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;
using Microsoft.AspNetCore.Http;

namespace Nop.Plugin.Widgets.NivoSliderClone.Models
{
    public record ConfigurationModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Picture")]
        [UIHint("Picture")]
        public int Picture1Id { get; set; }
        public IFormFile File1 { get; set; }
        public string Picture1Url { get; set; } = string.Empty;
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Text")]
        public string? Text1 { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Link")]
        public string? Link1 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Picture")]
        [UIHint("Picture")]
        public int Picture2Id { get; set; }
        public IFormFile File2 { get; set; }
        public string Picture2Url { get; set; } = string.Empty;
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Text")]
        public string Text2 { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Link")]
        public string Link2 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Picture")]
        [UIHint("Picture")]
        public int Picture3Id { get; set; }
        public IFormFile File3 { get; set; }
        public string Picture3Url { get; set; } = string.Empty;
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Text")]
        public string Text3 { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Link")]
        public string Link3 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Picture")]
        [UIHint("Picture")]
        public int Picture4Id { get; set; }
        public IFormFile File4 { get; set; }
        public string Picture4Url { get; set; } = string.Empty;
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Text")]
        public string Text4 { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Link")]
        public string Link4 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Picture")]
        [UIHint("Picture")]
        public int Picture5Id { get; set; }
        public IFormFile File5 { get; set; }
        public string Picture5Url { get; set; } = string.Empty;
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Text")]
        public string Text5 { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Link")]
        public string Link5 { get; set; }
    }
}