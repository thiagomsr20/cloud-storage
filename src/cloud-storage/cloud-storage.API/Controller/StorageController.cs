using Microsoft.AspNetCore.Mvc;
using cloud_storage.Application.UseCases.User.UploadProfilePhoto;

namespace cloud_storage.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            var UploadProfilePhoto = new UploadProfilePhotoUseCase();

            try
            {
                UploadProfilePhoto.Execute(file);
            }
            catch (Exception)
            {
                return BadRequest("The file isn't an image");
            }

            return Created();
        }
    }
}
