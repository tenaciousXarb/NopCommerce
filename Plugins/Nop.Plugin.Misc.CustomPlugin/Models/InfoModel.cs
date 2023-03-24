using Nop.Web.Framework.Models;

namespace Nop.Plugin.Misc.CustomPlugin.Models
{
    public record InfoModel : BaseNopModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}