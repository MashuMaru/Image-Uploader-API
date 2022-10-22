using ImageUploader.Models;
using Microsoft.AspNetCore.Http;

namespace ImageUploader.Interfaces
{
    public interface IUploadHandler
    {
         Task<ApiResponse<IFormFile>> UploadImageToContainer(IFormFile image);
    }
}