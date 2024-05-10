using BuildingManagementSystem.ConsumeApi.Clients.Abstract;
using BuildingManagementSystem.ConsumeApi.Models.BuildingViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BuildingManagementSystem.ConsumeApi.Clients.Concrete
{
    public class BuildingClient : IBuildingClient
    {
        private readonly IUserClient _userClient;

        public HttpClient _client { get; }
        public BuildingClient(HttpClient client)
        {
           
            client.BaseAddress = new Uri("https://localhost:44312/");            
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "BuildingClient");
            _client = client;
        }
        public async Task<HttpResponseMessage> BuildingList(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            return await _client.GetAsync("api/Building/getAll");
        }
        public async Task<HttpResponseMessage> AddBuilding(HttpRequestMessage request, BuildingVM model)
        {
            
            request.RequestUri = new Uri(_client.BaseAddress + "api/Building/addBuilding");
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            return await _client.SendAsync(request);
        }
        public async Task<HttpResponseMessage> UpdateBuilding(HttpRequestMessage request, BuildingVM model)
        {
            
            request.RequestUri = new Uri(_client.BaseAddress + "api/Building/updateBuilding");
                       
            var buildingModel = new StringContent(JsonConvert.SerializeObject(model),Encoding.UTF8,Application.Json);

            return await _client.PutAsync(request.RequestUri, buildingModel);           
        }       
        public async Task<HttpResponseMessage> DeleteBuilding(int id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _client.DeleteAsync("api/Building/deleteBuilding/" + id);           
        }
        public async Task<HttpResponseMessage> GetBuildingById(int id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _client.GetAsync("api/Building/buildingDetail/"+id);
           
        }
    }
}
