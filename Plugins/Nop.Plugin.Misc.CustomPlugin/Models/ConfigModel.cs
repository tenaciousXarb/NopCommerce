using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Misc.CustomPlugin.Models
{
    public record ConfigModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.Misc.CustomPlugin.Id")]
        public int Id { get; set; } = 1;
        [NopResourceDisplayName("Plugins.Misc.CustomPlugin.FullName")]
        public string FullName { get; set; }
        [NopResourceDisplayName("Plugins.Misc.CustomPlugin.Email")]
        public string Email { get; set; }
    }
}