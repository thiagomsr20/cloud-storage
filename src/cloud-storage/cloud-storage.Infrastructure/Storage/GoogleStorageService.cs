using cloud_storage.Domain.Entities;
using cloud_storage.Domain.Storage;
using Microsoft.AspNetCore.Http;

namespace cloud_storage.Infrastructure.Storage
{
    public class GoogleStorageService : IStorageService
    {
        public string Upload(IFormFile file, User user)
        {
            return "";
        }
    }
}
