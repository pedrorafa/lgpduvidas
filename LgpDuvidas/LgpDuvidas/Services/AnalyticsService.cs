using LgpDuvidas.Data;
using LgpDuvidas.Interfaces;
using LgpDuvidas.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LgpDuvidas.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private IDbContext _dbContext => DependencyService.Get<IDbContext>();
        private readonly HttpClient _client;

        public AnalyticsService()
        {
            var auth = _dbContext.Connection.Table<AuthModel>().FirstOrDefault() ?? new AuthModel();
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://lgpduvidas.azurewebsites.net/api/")
            };
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.Token);
        }
        public async Task<IEnumerable<Message>> GetMessages()
        {
            try
            {
                var response = _client.GetAsync("messages");
                response.Wait();

                response.Result.EnsureSuccessStatusCode();
                var strRes = await response.Result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<Message>>(strRes);

            }
            catch (Exception err)
            {
                return null;
            }
        }
    }
}
