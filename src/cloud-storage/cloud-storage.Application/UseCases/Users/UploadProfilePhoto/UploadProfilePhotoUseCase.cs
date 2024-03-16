using cloud_storage.Domain.Storage;
using cloud_storage.Domain.Entities;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;

namespace cloud_storage.Application.UseCases.Users.UploadProfilePhoto
{
    public class UploadProfilePhotoUseCase
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
            bool fileValid = fileStream.Is<JointPhotographicExpertsGroup>();

            if (fileValid is false)
                throw new Exception("The file isn't an image.");

            var user = GetFromDatabase();

            _storageService.Upload(file, user);
        }

        private User GetFromDatabase()
        {
            User X = new User();

            return new User
            {
                Id = 1,
                Name = "Thiago",
                Email = "thiagomsoares1230@gmail.com",
            };
        }
    }
}