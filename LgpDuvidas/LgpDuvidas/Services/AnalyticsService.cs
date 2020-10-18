using LgpDuvidas.Data;
using LgpDuvidas.Interfaces;
using LgpDuvidas.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LgpDuvidas.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private IDbContext _dbContext => DependencyService.Get<IDbContext>();

        private readonly HttpClient _client;
        private AuthModel auth;

        public AnalyticsService()
        {
            auth = _dbContext.Connection.Table<AuthModel>().FirstOrDefault() ?? new AuthModel();
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://lgpduvidas.azurewebsites.net/api/")
            };
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.Token);
        }

        public async Task<IEnumerable<Entity>> GetMessages()
        {
            try
            {
                var response = await _client.GetAsync("messages");

                response.EnsureSuccessStatusCode();

                var strRes = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<Entity>>(strRes);

            }
            catch (Exception err)
            {
                return null;
            }
        }
    }
}
