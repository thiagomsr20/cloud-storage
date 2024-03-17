using Microsoft.AspNetCore.Http;

namespace cloud_storage.Application.UseCases.Users.UploadProfilePhoto
{
    public interface IUploadProfilePhotoUseCase
    {
        void Execute(IFormFile file);
    }
}
