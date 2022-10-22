using Azure.Storage.Blobs;
using Azure.Storage;
using ImageUploader.Data.Interfaces;
using ImageUploader.Interfaces;
using ImageUploader.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ImageUploader.Handlers
{
  public class UploadHandler : IUploadHandler
  {
    private readonly IUploadRepository _uploadRepository;
    private readonly IConfiguration _configuration;

    public UploadHandler (
      IUploadRepository uploadRepository, 
      IConfiguration configuration)
    {
      _uploadRepository = uploadRepository;
      _configuration = configuration;
    }
    public async Task<ApiResponse<IFormFile>> UploadImageToContainer(IFormFile image)
    {
      var connectionString = _configuration["ConnectionString"];
      var containerName = _configuration["ContainerName"];
      var imageUri = $"{containerName}/{image.FileName}";
      var blobClient = new BlobClient(connectionString, imageUri, containerName);

      await blobClient.UploadAsync(image.OpenReadStream(), overwrite: true).ConfigureAwait(false);

      await _uploadRepository.SaveUploadAudit(new UploadAuditDataModel()
      {
        Id = Guid.NewGuid(),
        UploadDateTime = DateTime.UtcNow,
        FileName = image.FileName
      });

      return new ApiResponse<IFormFile>
      {
        Message = "Successfully uploaded the image.",
        IsSuccessful = true,
        Data = image
      };
    }
  }
}