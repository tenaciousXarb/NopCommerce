using Nop.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.NivoSliderClone.Domain
{
    public class ImageModel : BaseEntity
    {
        [Key]
        public new int Id { get; set; }
        public byte[] MetaData { get; set; }
        public string Extension { get; set; }
        public string Comment { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
    }
}
