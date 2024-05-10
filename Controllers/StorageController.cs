using BuildingManagementSystem.ConsumeApi.Clients.Abstract;
using BuildingManagementSystem.ConsumeApi.Models.BuildingViewModels;
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
    public class StorageController : Controller
    {
        private readonly IStorageClient _client;
        private readonly IBuildingClient _buildingClient;

        public StorageController(IStorageClient client,IBuildingClient buildingClient)
        {
            _client = client;
            _buildingClient = buildingClient;
        }
        public async Task<IActionResult> StorageList()
        {
            string token = HttpContext.Session.GetString("AccessToken");
            if (token == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                List<StorageVM> storageList = new List<StorageVM>();

                var result = await _client.StorageList(token);

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    storageList = JsonConvert.DeserializeObject<List<StorageVM>>(data);
                    return View(storageList);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
             
            
        }
        public async Task<IActionResult> AddStorage(int id)
        {
            string token = HttpContext.Session.GetString("AccessToken");
            if (token == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                if (id == 0)
                {
                    List<BuildingVM> buildingList = new List<BuildingVM>();
                    var building = await _buildingClient.BuildingList(token);
                    string data = building.Content.ReadAsStringAsync().Result;
                    buildingList = JsonConvert.DeserializeObject<List<BuildingVM>>(data);
                    ViewBag.BuildingList = buildingList;
                }
                else
                {
                    var building = await _buildingClient.GetBuildingById(id, token);
                    string data = building.Content.ReadAsStringAsync().Result;
                    var buildingInfo = JsonConvert.DeserializeObject<BuildingVM>(data);
                    ViewBag.BuildingName = buildingInfo.Name;
                    ViewBag.BuildingID = buildingInfo.BuildingID;
                }

                return View();
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> AddStorage(StorageVM model)
        {
                if (ModelState.IsValid)
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    var result = await _client.AddStorage(request, model);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("StorageList");
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

        [HttpGet]
        public async Task<IActionResult> UpdateStorage(int id)
        {
            string token = HttpContext.Session.GetString("AccessToken");
            if (token == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                StorageVM storage = new StorageVM();

                var result = await _client.GetStorageById(id,token);

                if (result.IsSuccessStatusCode)
                {
                    List<BuildingVM> buildingList = new List<BuildingVM>();
                    var building = await _buildingClient.BuildingList(token);
                    string buildingData = building.Content.ReadAsStringAsync().Result;
                    buildingList = JsonConvert.DeserializeObject<List<BuildingVM>>(buildingData);
                    ViewBag.BuildingList = buildingList;

                    string data = result.Content.ReadAsStringAsync().Result;
                    storage = JsonConvert.DeserializeObject<StorageVM>(data);
                    return View(storage);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
              
            
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStorage(StorageVM model)
        {
                if (ModelState.IsValid)
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    var result = await _client.UpdateStorage(request, model);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("StorageList");
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

        public async Task<IActionResult> DeleteStorage(int id)
        {
            string token = HttpContext.Session.GetString("AccessToken");
            if (token == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                var storage = await _client.GetStorageById(id,token);
                if (storage != null)
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    var result = await _client.DeleteStorage(id,token);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("StorageList");
                    }
                    else
                    {
                        return RedirectToAction("Error", "Home");
                    }


                }
                else
                {

                    return RedirectToAction("StorageList");
                }
            }

        }

        
    }
}
