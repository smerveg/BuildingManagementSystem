
using BuildingManagementSystem.ConsumeApi.Models.RoomViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RoomManagementSystem.ConsumeApi.Clients.Abstract
{
    public interface IRoomClient
    {
        Task<HttpResponseMessage> RoomList(string token);
        Task<HttpResponseMessage> GetRoomById(int id, string token);
        Task<HttpResponseMessage> AddRoom(HttpRequestMessage request, RoomVM model);
        Task<HttpResponseMessage> UpdateRoom(HttpRequestMessage request, RoomVM model);
        Task<HttpResponseMessage> DeleteRoom(int id, string token);
    }
}
