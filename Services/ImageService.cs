using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorStore.Services
{
    public class ImageService : IImageService
    {
        public async Task<byte[]> EncodeFileAsync(IFormFile image)
        {
            if (image == null)
            {
                return null;
            }
            using var stream = new MemoryStream();
            await image.CopyToAsync(stream);
            return stream.ToArray();
        }

        public string RecordContentType(IFormFile image)
        {
            if (image == null)
            {
                return null;
            }
            return image.ContentType;
        }
        public string DecodeFile(byte[] imageData, string contentType)
        {
            if (imageData == null || contentType == null)
            {
                return "https://via.placeholder.com/550x750";
            }
            var imageArray = Convert.ToBase64String(imageData);
            return $"data:{contentType};base64,{imageArray}";
        }
        public string DecodeFileForCart(byte[] imageData, string contentType)
        {
            if (imageData == null)
            {
                return "https://placehold.it/100x100";
            }
            var imageArray = Convert.ToBase64String(imageData);
            return $"data:{contentType};base64,{imageArray}";
        }
        public string DecodeFileAvatar(byte[] imageData, string contentType)
        {
            if (imageData == null)
            {
                return "/images/avatar.png";
            }
            var imageArray = Convert.ToBase64String(imageData);
            return $"data:{contentType};base64,{imageArray}";
        }

        public string DecodeFileBlogPost(byte[] imageData, string contentType)
        {
            if (imageData == null || contentType == null)
            {
                return "https://via.placeholder.com/750x300";
            }
            var imageArray = Convert.ToBase64String(imageData);
            return $"data:{contentType};base64,{imageArray}";
        }
    }
}
