using cloud_storage.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace cloud_storage.Domain.Storage
{
    public interface IStorageService
    {
        string Upload(IFormFile file, User user);
    }
}
