using BuildingManagementSystem.ConsumeApi.Clients.Abstract;
using BuildingManagementSystem.ConsumeApi.Models.UserViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.ConsumeApi.Clients.Concrete
{
    public class UserClient:IUserClient
    {
        public HttpClient _client { get; }
        public UserClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44312/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "UserClient");
            _client = client;
        }

        public async Task<string> GenerateToken(UserVM model)
        {
            var data = JsonConvert.SerializeObject(model);
            
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_client.BaseAddress + "api/User/generateToken"),
            Content = new StringContent(data, Encoding.UTF8, MediaTypeNames.Application.Json),
            };
            HttpResponseMessage response = await _client.SendAsync(request);
            HttpContent Content = response.Content;
            var token = await Content.ReadAsStringAsync();
            if (token.Contains("error"))
            {
                token = null;
            }
            
            return token;
            
            
           
        }
    }
}
