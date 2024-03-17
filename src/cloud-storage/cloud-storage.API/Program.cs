using cloud_storage.Application.UseCases.Users.UploadProfilePhoto;
using cloud_storage.Domain.Storage;
using cloud_storage.Infrastructure.Storage;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependência em projetos de webapi com ASP, ficam no Program.cs
builder.Services.AddScoped<IUploadProfilePhotoUseCase, UploadProfilePhotoUseCase>();
builder.Services.AddScoped<IStorageService>(options =>
{
   var clientId = builder.Configuration.GetValue<string>("cloud-storage:ClientId");
    var clientSecret = builder.Configuration.GetValue<string>("cloud-storage:ClientSecret");

   var apiCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
    {
        ClientSecrets = new Google.Apis.Auth.OAuth2.ClientSecrets
        {
            ClientId = clientId,
            ClientSecret = clientSecret
        },
        Scopes = [DriveService.Scope.Drive],
        DataStore = new FileDataStore("cloud-storage") // Usando

    });

    return new GoogleStorageService(apiCodeFlow);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
