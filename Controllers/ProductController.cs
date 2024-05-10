using BuildingManagementSystem.ConsumeApi.Clients.Abstract;
using BuildingManagementSystem.ConsumeApi.Models.ProductViewModels;
using BuildingManagementSystem.ConsumeApi.Models.StorageViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuildingManagementSystem.ConsumeApi.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductClient _client;
        private readonly IStorageClient _storageClient;

        public ProductController(IProductClient client,IStorageClient storageClient)
        {
            _client = client;
            _storageClient = storageClient;

        }
        public async Task<IActionResult> ProductList()
        {
            string token = HttpContext.Session.GetString("AccessToken");
            if (token == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                List<ProductVM> productList = new List<ProductVM>();

                var result = await _client.ProductList(token);

                if (result.IsSuccessStatusCode)
                {

                    string data = result.Content.ReadAsStringAsync().Result;
                    productList = JsonConvert.DeserializeObject<List<ProductVM>>(data);
                    return View(productList);

                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            
            
        }
        public async Task<IActionResult> AddProduct()
        {
            string token = HttpContext.Session.GetString("AccessToken");
            if (token == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                List<StorageVM> storageList = new List<StorageVM>();
                var building = await _storageClient.StorageList(token);
                string data = building.Content.ReadAsStringAsync().Result;
                storageList = JsonConvert.DeserializeObject<List<StorageVM>>(data);
                ViewBag.StorageList = storageList;

                return View();
            }

                
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductVM model)
        {
                if (ModelState.IsValid)
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    var result = await _client.AddProduct(request, model);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ProductList");
                    }
                    else
                    {
                        return RedirectToAction("Error", "Home");
                    }

                }
                else
                {

                    return View(model);
                }
            
            
        }

    }
}
