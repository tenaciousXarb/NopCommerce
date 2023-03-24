using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Media;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Plugin.Widgets.NivoSliderClone.Domain;
using Nop.Services.Media;
using Org.BouncyCastle.Utilities;
using System.Security.Cryptography.X509Certificates;

namespace Nop.Plugin.Widgets.NivoSliderClone.Services
{
    public class ImageService : IImageService
    {
        private readonly IRepository<ImageModel> _imageRepository;
        private readonly IPictureService _pictureService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHelper _webHelper;
        private readonly INopFileProvider _fileProvider;

        public ImageService(IRepository<ImageModel> imageRepository, IPictureService pictureService, IHttpContextAccessor httpContextAccessor, IWebHelper webHelper, INopFileProvider fileProvider)
        {
            _imageRepository = imageRepository;
            _pictureService = pictureService;
            _httpContextAccessor = httpContextAccessor;
            _webHelper = webHelper;
            _fileProvider = fileProvider;
        }

        public async Task InsertImageAsync(ImageModel model)
        {
            await _imageRepository.InsertAsync(model, false);
        }

        public async Task<IList<ImageModel>> GetAllImageAsync()
        {
            var images = await _imageRepository.GetAllAsync(query =>
            {
                return from sbw in query
                       orderby sbw.Id
                       select sbw;
            }, cache => null);

            return images;
        }

        public async Task<ImageModel> GetImageByIdAsync(int id)
        {
            return await _imageRepository.GetByIdAsync(id);
        }

        public async Task UpdateImageAsync(ImageModel model)
        {
            await _imageRepository.UpdateAsync(model, false);
        }

        public async Task DeleteAllImageAsync(IList<ImageModel> models)
        {
            await _imageRepository.DeleteAsync(models, false);
        }

        public async Task DeleteImageAsync(ImageModel model)
        {
            await _imageRepository.DeleteAsync(model, false);
        }

        public async Task<string> GetPictureUrlAsync(int id, bool showDefaultPicture = true)
        {
            var image = await _imageRepository.GetByIdAsync(id);
            if(image == null || image.MetaData == null)
            {
                return showDefaultPicture ? (await _pictureService.GetDefaultPictureUrlAsync(targetSize: 0, defaultPictureType: PictureType.Entity, storeLocation: null)): (string.Empty);
            }
            else
            {
                var lastPart = await GetFileExtensionFromMimeTypeAsync(image.Extension);

                string thumbFileName = !string.IsNullOrEmpty(image.FileName)
                    ? $"image{image.Id:0000000}_{image.FileName}.{lastPart}"
                : $"image{image.Id:0000000}.{lastPart}";

                var path = _fileProvider.GetAbsolutePath(NopMediaDefaults.ImageThumbsPath);

                var thumbFilePath = _fileProvider.Combine(path, thumbFileName);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (File.Exists(thumbFilePath))
                {
                    File.Delete(thumbFilePath);
                }

                using var mutex = new Mutex(false, thumbFileName);
                mutex.WaitOne();
                try
                {
                    File.WriteAllBytesAsync(thumbFilePath, image.MetaData).Wait();
                }
                finally
                {
                    mutex.ReleaseMutex();
                }

                return await GetThumbUrlAsync(thumbFileName);
            }            
        }

        private async Task<string> GetThumbUrlAsync(string thumbFileName)
        {
            var storeUrl = _webHelper.GetStoreLocation();
            var thumbImagesPathUrl = "images/thumbs/";
            var url = storeUrl + thumbImagesPathUrl;

            url += thumbFileName;

            return url;
        }

        public async Task<string> GetFileExtensionFromMimeTypeAsync(string mimeType)
        {
            if (mimeType == null)
            {
                return await Task.FromResult<string>(null);
            }
            else
            {
                var parts = mimeType.Split('/');
                var lastPart = parts[^1];
                switch (lastPart)
                {
                    case "pjpeg":
                        lastPart = "jpg";
                        break;
                    case "jpeg":
                        lastPart = "jpg";
                        break;
                    default:
                        break;
                }

                return await Task.FromResult(lastPart);
            }
        }
    }
}
