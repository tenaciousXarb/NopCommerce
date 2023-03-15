using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.NivoSliderClone.Models
{
    public record ConfigurationModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Picture")]
        [UIHint("Picture")]
        public int Picture1Id { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Text")]
        public string Text1 { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Link")]
        public string Link1 { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.AltText")]
        public string AltText1 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Picture")]
        [UIHint("Picture")]
        public int Picture2Id { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Text")]
        public string Text2 { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Link")]
        public string Link2 { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.AltText")]
        public string AltText2 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Picture")]
        [UIHint("Picture")]
        public int Picture3Id { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Text")]
        public string Text3 { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Link")]
        public string Link3 { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.AltText")]
        public string AltText3 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Picture")]
        [UIHint("Picture")]
        public int Picture4Id { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Text")]
        public string Text4 { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Link")]
        public string Link4 { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.AltText")]
        public string AltText4 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Picture")]
        [UIHint("Picture")]
        public int Picture5Id { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Text")]
        public string Text5 { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.Link")]
        public string Link5 { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.NivoSliderClone.AltText")]
        public string AltText5 { get; set; }
    }
}