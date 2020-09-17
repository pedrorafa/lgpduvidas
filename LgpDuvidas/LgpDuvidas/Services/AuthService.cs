using LgpDuvidas.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LgpDuvidas.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;

        public AuthService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://lgpduvidas.azurewebsites.net/api/")
            };
        }
        public async Task<UserModel> Register(UserModel input)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("register", content);

                response.EnsureSuccessStatusCode();
                await response.Content.ReadAsStringAsync();
            }
            catch (Exception err)
            {
            }
            return input;

        }
        public async Task<UserModel> Login(UserModel input)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("login", content);

                response.EnsureSuccessStatusCode();
                input.Token = await response.Content.ReadAsStringAsync();
            }
            catch (Exception err)
            {
            }
            return input;
        }
    }
}
