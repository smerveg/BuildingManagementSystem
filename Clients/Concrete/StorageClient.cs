using BuildingManagementSystem.ConsumeApi.Clients.Abstract;
using BuildingManagementSystem.ConsumeApi.Models.StorageViewModels;
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
    public class StorageClient:IStorageClient
    {
        public HttpClient _client { get; }
        public StorageClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44312/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "StorageClient");
            _client = client;
        }
        public async Task<HttpResponseMessage> StorageList(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _client.GetAsync("api/Storage/getAll");
        }
        public async Task<HttpResponseMessage> AddStorage(HttpRequestMessage request, StorageVM model)
        {          
            request.RequestUri = new Uri(_client.BaseAddress + "api/Storage/addStorage");
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            return await _client.SendAsync(request);
        }
        public async Task<HttpResponseMessage> UpdateStorage(HttpRequestMessage request, StorageVM model)
        {
            request.RequestUri = new Uri(_client.BaseAddress + "api/Storage/updateStorage");

            var storageModel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, Application.Json);

            return await _client.PutAsync(request.RequestUri, storageModel);
        }
        public async Task<HttpResponseMessage> DeleteStorage(int id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _client.DeleteAsync("api/Storage/deleteStorage/" + id);
        }
        public async Task<HttpResponseMessage> GetStorageById(int id,string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var r = await _client.GetAsync("api/Storage/storageDetail/" + id);
            return r;
        }
    }
}
