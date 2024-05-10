using BuildingManagementSystem.ConsumeApi.Clients.Abstract;
using BuildingManagementSystem.ConsumeApi.Models.BuildingViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuildingManagementSystem.ConsumeApi.Controllers
{
   
    public class BuildingController : Controller
    {
        private readonly IBuildingClient _client;

        public BuildingController(IBuildingClient client)
        {            
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> BuildingList()
        {           
            string token = HttpContext.Session.GetString("AccessToken");
            if (token==null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                List<BuildingVM> buildingList = new List<BuildingVM>();

                var result = await _client.BuildingList(token);

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    buildingList = JsonConvert.DeserializeObject<List<BuildingVM>>(data);
                    return View(buildingList);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            
            
        }

        public IActionResult AddBuilding()
        {
            string token = HttpContext.Session.GetString("AccessToken");
            if (token == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBuilding(BuildingVM model)
        {
            
                if (ModelState.IsValid)
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    var result = await _client.AddBuilding(request, model);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("BuildingList");
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
        public async Task<IActionResult> UpdateBuilding(int id)
        {
            string token = HttpContext.Session.GetString("AccessToken");
            if (token == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                BuildingVM building = new BuildingVM();

                var result = await _client.GetBuildingById(id,token);

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    building = JsonConvert.DeserializeObject<BuildingVM>(data);
                    return View(building);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }

            

           
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBuilding(BuildingVM model)
        {
           
                if (ModelState.IsValid)
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    var result = await _client.UpdateBuilding(request, model);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("BuildingList");
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

        public async Task<IActionResult> DeleteBuilding(int id)
        {
            string token = HttpContext.Session.GetString("AccessToken");
            if (token == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                var building = await _client.GetBuildingById(id,token);
                if (building != null)
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    var result = await _client.DeleteBuilding(id,token);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("BuildingList");
                    }
                    else
                    {
                        return RedirectToAction("Error", "Home");
                    }

                }
                else
                {

                    return RedirectToAction("BuildingList");
                }
            }
           
        }
        
    }
}
