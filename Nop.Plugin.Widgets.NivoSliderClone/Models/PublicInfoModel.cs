using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.NivoSliderClone.Models
{
    public record PublicInfoModel : BaseNopModel
    {
        public string PictureUrl { get; set; }
        public string Comment { get; set; }
        public string Url { get; set; }
        public string Extension { get; set; }
    }
}