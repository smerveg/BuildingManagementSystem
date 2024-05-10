using BuildingManagementSystem.ConsumeApi.Models.BuildingViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuildingManagementSystem.ConsumeApi.Clients.Abstract
{
    public interface IBuildingClient
    {
        Task<HttpResponseMessage> BuildingList(string token);
        Task<HttpResponseMessage> GetBuildingById(int id, string token);
        Task<HttpResponseMessage> AddBuilding(HttpRequestMessage request, BuildingVM model);
        Task<HttpResponseMessage> UpdateBuilding(HttpRequestMessage request, BuildingVM model);
        Task<HttpResponseMessage> DeleteBuilding( int id, string token);
    }
}
