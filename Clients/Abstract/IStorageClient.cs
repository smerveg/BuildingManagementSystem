using BuildingManagementSystem.ConsumeApi.Models.StorageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuildingManagementSystem.ConsumeApi.Clients.Abstract
{
    public interface IStorageClient
    {
        Task<HttpResponseMessage> StorageList(string token);
        Task<HttpResponseMessage> GetStorageById(int id, string token);
        Task<HttpResponseMessage> AddStorage(HttpRequestMessage request, StorageVM model);
        Task<HttpResponseMessage> UpdateStorage(HttpRequestMessage request, StorageVM model);
        Task<HttpResponseMessage> DeleteStorage(int id, string token);
    }
}
