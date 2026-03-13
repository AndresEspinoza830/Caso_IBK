using BFF.Infrastucture.ExternalModel;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using BFF.Application.Interfaces;
using BFF.Application.Models;

namespace BFF.Infrastucture.Repository
{
    public class ProfileRepository(HttpClient _httpClient, IConfiguration _configuration) : IProfileRepository
    {
        public async Task<UserResponse> GetUser(int id)
        {
            var baseUrl = _configuration["ExternalServices:UserService"];

            var response = await _httpClient.GetAsync($"{baseUrl}/api/user/{id}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<UserServiceResponse>();

            if (result is null)
                throw new InvalidOperationException("User service returned empty response");

            return new UserResponse
            {
                Id = result.Id,
                Name = result.Name,
                Avatar = result.Avatar
            };
        }

        public async Task<PhotoResponse> GetPhoto(int id)
        {
            var baseUrl = _configuration["ExternalServices:PhotoService"];

            var response = await _httpClient.GetAsync($"{baseUrl}/api/photo/{id}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<PhotoServiceResponse>();

            if (result is null)
                throw new InvalidOperationException("Photo service returned empty response");

            return new PhotoResponse
            {
                Image = result.ImageBase64
            };
        }
    }
}
