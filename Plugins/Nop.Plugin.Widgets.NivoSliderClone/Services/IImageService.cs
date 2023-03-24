using Nop.Core.Domain.Media;
using Nop.Plugin.Widgets.NivoSliderClone.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.NivoSliderClone.Services
{
    public interface IImageService
    {
        Task<ImageModel> GetImageByIdAsync(int id);

        Task<IList<ImageModel>> GetAllImageAsync();

        Task UpdateImageAsync(ImageModel model);

        Task InsertImageAsync(ImageModel model);

        Task DeleteAllImageAsync(IList<ImageModel> models);

        Task DeleteImageAsync(ImageModel model);

        Task<string> GetPictureUrlAsync(int id, bool showDefaultPicture = true);
    }
}
