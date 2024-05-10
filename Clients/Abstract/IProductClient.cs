using BuildingManagementSystem.ConsumeApi.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuildingManagementSystem.ConsumeApi.Clients.Abstract
{
    public interface IProductClient
    {
        Task<HttpResponseMessage> ProductList(string token);
        Task<HttpResponseMessage> AddProduct(HttpRequestMessage request, ProductVM model);
    }
}
