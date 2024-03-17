using Microsoft.AspNetCore.Mvc;
using cloud_storage.Application.UseCases.Users.UploadProfilePhoto;

namespace cloud_storage.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        [HttpPost]
        public IActionResult UploadFile([FromServices] IUploadProfilePhotoUseCase useCase, IFormFile file)
        {
            try
            {
                useCase.Execute(file);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }

            return Created();
        }
    }
}
