using BuildingManagementSystem.ConsumeApi.Models.RoomViewModels;
using Newtonsoft.Json;
using RoomManagementSystem.ConsumeApi.Clients.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RoomManagementSystem.ConsumeApi.Clients.Concrete
{
    public class RoomClient:IRoomClient
    {
        public HttpClient _client { get; }
        public RoomClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44312/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "RooClientClient");
            _client = client;
        }
        public async Task<HttpResponseMessage> RoomList(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _client.GetAsync("api/Room/getAll");
        }
        public async Task<HttpResponseMessage> AddRoom(HttpRequestMessage request, RoomVM model)
        {
            request.RequestUri = new Uri(_client.BaseAddress + "api/Room/addRoom");
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            return await _client.SendAsync(request);
        }
        public async Task<HttpResponseMessage> UpdateRoom(HttpRequestMessage request, RoomVM model)
        {
            request.RequestUri = new Uri(_client.BaseAddress + "api/Room/updateRoom");

            var roomModel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, Application.Json);

            return await _client.PutAsync(request.RequestUri, roomModel);
        }
        public async Task<HttpResponseMessage> DeleteRoom(int id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _client.DeleteAsync("api/Room/deleteRoom/" + id);
        }
        public async Task<HttpResponseMessage> GetRoomById(int id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var r = await _client.GetAsync("api/Room/roomDetail/" + id);
            return r;
        }
    }
}
