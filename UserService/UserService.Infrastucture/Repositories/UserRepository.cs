
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Infrastucture.ExternalModel;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace UserService.Infrastucture.Repository
{
    public class UserRepository(HttpClient _httpClient, IConfiguration _configuration) : IUserRepository   
    {
        public async Task<User> GetUser(int id)
        {
            var baseUrl = _configuration.GetValue<string>("ExternalServices:ReqResUserUrl");
            var apiKey = _configuration.GetValue<string>("ExternalServices:ReqResApiKey");

            _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);

            var response = await _httpClient.GetAsync($"{baseUrl}{id}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ReqResResponse>();

            if(result is null || result.Data is null)
            {
                throw new InvalidOperationException("User not found in external service.");
            }

            return new User
            {
                Id = result.Data.Id,
                FirstName = result.Data.First_Name,
                LastName = result.Data.Last_Name,
                Email = result.Data.Email,
                Avatar = result.Data.Avatar
            };
        }
    }
}
