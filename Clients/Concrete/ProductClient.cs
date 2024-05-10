using BuildingManagementSystem.ConsumeApi.Clients.Abstract;
using BuildingManagementSystem.ConsumeApi.Models.ProductViewModels;
using BuildingManagementSystem.ConsumeApi.Models.StorageViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BuildingManagementSystem.ConsumeApi.Clients.Concrete
{
    public class ProductClient:IProductClient
    {
        public HttpClient _client { get; }
        public ProductClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44312/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ProductClient");
            _client = client;
        }
        public async Task<HttpResponseMessage> ProductList(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _client.GetAsync("api/Product/getAll");
        }
        public async Task<HttpResponseMessage> AddProduct(HttpRequestMessage request, ProductVM model)
        {
            
            StorageVM storage = new StorageVM();
            storage.StorageID = model.StorageID;
            storage.Quantity = model.Quantity;

            model.Storages = new List<StorageVM>();
            model.Storages.Add(storage);
            request.RequestUri = new Uri(_client.BaseAddress + "api/Product/addProduct");
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            return await _client.SendAsync(request);
        }
    }
}
