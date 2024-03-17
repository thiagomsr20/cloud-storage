using cloud_storage.Domain.Entities;
using cloud_storage.Domain.Storage;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Http;
using Google.Apis.Upload;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Auth.OAuth2.Flows;

using GoogleFile = Google.Apis.Drive.v3.Data.File;
using GoogleInitializer = Google.Apis.Services.BaseClientService.Initializer;

namespace cloud_storage.Infrastructure.Storage
{
    public class GoogleStorageService : IStorageService
    {
        private readonly GoogleAuthorizationCodeFlow _authorization;
        public GoogleStorageService(GoogleAuthorizationCodeFlow authorization)
        {
            _authorization = authorization;
        }

        public string Upload(IFormFile file, User user)
        {
            var credential = new UserCredential(_authorization, user.Email, new TokenResponse
            {
                AccessToken = user.AccessToken,
                RefreshToken = user.RefreshToken
            });

            var service = new DriveService(new GoogleInitializer
            {
                ApplicationName = "cloud-storage",
                HttpClientInitializer = credential
            });

            var driveFile = new GoogleFile
            {
                Name = file.Name,
                MimeType = file.ContentType,
                // A prop Parents, serve para identificar a psta onde colcoar esse file
            };

            var command = service.Files.Create(driveFile, file.OpenReadStream(), file.ContentType);
            var response = command.Upload();

            if (response.Status is not UploadStatus.Completed)
                throw new Exception("The upload command isn't done");
                
            // Retorna Id do arquivo enviado, possibildiade de futuro uso para deletar
            return command.ResponseBody.Id;
        }
    }
}
