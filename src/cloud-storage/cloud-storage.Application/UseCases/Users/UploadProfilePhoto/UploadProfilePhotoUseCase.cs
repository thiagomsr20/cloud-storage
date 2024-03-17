using cloud_storage.Domain.Storage;
using cloud_storage.Domain.Entities;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;

namespace cloud_storage.Application.UseCases.Users.UploadProfilePhoto
{
    public class UploadProfilePhotoUseCase : IUploadProfilePhotoUseCase
    {
        private readonly IStorageService _storageService;
        public UploadProfilePhotoUseCase(IStorageService storageService)
        {
            _storageService = storageService;
        }

        /// <summary>
        /// Se temos uma classe que implementa  algo tão específico, é interessante adicionar um START.
        /// Então quando o controller da API for utilar essa regra de negócio, ele apenas irá executar essa regra de negócio
        /// </summary>
        public void Execute(IFormFile file)
        {
            var fileStream = file.OpenReadStream();

            if (fileStream.Is<JointPhotographicExpertsGroup>() == false && fileStream.Is<PortableNetworkGraphic>() == false)
                throw new Exception("The file isn't an image.");

            var user = GetFromDatabase();
            _storageService.Upload(file, user);
        }

        private User GetFromDatabase()
        {
            return new User
            {
                Id = 1,
                Name = "Thiago",
                Email = "thiagomsoares1230@gmail.com",
                RefreshToken = "1//04kH4mJkIyAvtCgYIARAAGAQSNwF-L9IrK_kt5ipTFZfVo6yTw4xZxENvX4cdUzVPLVYg-_OmaFXcDwQwAbEL4kvrqg56mRwWeMI",
                AccessToken = "ya29.a0Ad52N39U-_ryV-WR_aHCo0fFYix5LmaL3A-yp3zih-9BFY2snuvfJwH4SzT9-Xok0hD5_0CjkLrw75TI3FfYBf5VdigmatXpSqpxQR428tIgxAoTta7EAyCm952z-_SFTwWvGww4Wuu__EtvZElfHiyQUYDP2NzdvoC4aCgYKAQMSARISFQHGX2MiLFaj7a9vtyszrJiCaXLYSg0171"
            };
        }
    }
}