using ImageUploader.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImageUploader.Api.Controllers;

[ApiController]
[Route("api")]
public class UploadController : ControllerBase
{
    private readonly ILogger<UploadController> _logger;
    private readonly IUploadHandler _uploadHandler;

    public UploadController(
        ILogger<UploadController> logger,
        IUploadHandler uploadHandler)
    {
        _logger = logger;
        _uploadHandler = uploadHandler;
    }

    [HttpPost("upload")]
    public async Task<ActionResult<IFormFile>> UploadImage(IFormFile image)
    {
        if (image is null)
            return BadRequest("Image must be provided.");

        var result = await _uploadHandler.UploadImageToContainer(image).ConfigureAwait(false);

        if (!result.IsSuccessful)
            return BadRequest(result.Message);

        return Ok(result.Data);
    }
}
