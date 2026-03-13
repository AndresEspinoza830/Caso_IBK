
using PhotoService.Application.Interfaces;
using PhotoService.Domain.Entities;
using Microsoft.Extensions.Configuration;


namespace PhotoService.Infrastucture.Repository
{
    public class PhotoRepository(HttpClient _httpClient, IConfiguration _configuration) : IPhotoRepository
    {
        public async Task<UserPhoto> GetUserPhoto(int id)
        {
            var url = _configuration.GetValue<string>("ExternalServices:ReqResUserUrl") ?? "";
            var apiKey = _configuration.GetValue<string>("ExternalServices:ReqResApiKey");
            var baseUrl = string.Format(url, id);

            _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);

            var bytes = await _httpClient.GetByteArrayAsync(baseUrl);

            var base64 = Convert.ToBase64String(bytes);

            return new UserPhoto
            {
                UserId = id,
                ImageBase64 = base64
            };
        }
    }
}
