using RoomManagementSystem.ConsumeApi.Clients.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingManagementSystem.ConsumeApi.Models.RoomViewModels;
using System.Net.Http;
using BuildingManagementSystem.ConsumeApi.Clients.Abstract;
using BuildingManagementSystem.ConsumeApi.Models.BuildingViewModels;
using Microsoft.AspNetCore.Http;

namespace RoomManagementSystem.ConsumeApi.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomClient _client;
        private readonly IBuildingClient _buildingClient;

        public RoomController(IRoomClient client,IBuildingClient buildingClient)
        {
            _client = client;
            _buildingClient = buildingClient;
        }
        public async Task<IActionResult> RoomList()
        {
            string token = HttpContext.Session.GetString("AccessToken");
            if (token == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                List<RoomVM> roomList = new List<RoomVM>();

                var result = await _client.RoomList(token);

                if (result.IsSuccessStatusCode)
                {

                    string data = result.Content.ReadAsStringAsync().Result;
                    roomList = JsonConvert.DeserializeObject<List<RoomVM>>(data);
                    return View(roomList);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
                
            
        }
        public async Task<IActionResult> AddRoom(int id)
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
        public async Task<IActionResult> AddRoom(RoomVM model)
        {
                if (ModelState.IsValid)
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    var result = await _client.AddRoom(request, model);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("RoomList");
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
        public async Task<IActionResult> UpdateRoom(int id)
        {
            string token = HttpContext.Session.GetString("AccessToken");
            if (token == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                RoomVM room = new RoomVM();

                var result = await _client.GetRoomById(id,token);

                if (result.IsSuccessStatusCode)
                {
                    List<BuildingVM> buildingList = new List<BuildingVM>();
                    var building = await _buildingClient.BuildingList(token);
                    string buildingData = building.Content.ReadAsStringAsync().Result;
                    buildingList = JsonConvert.DeserializeObject<List<BuildingVM>>(buildingData);
                    ViewBag.BuildingList = buildingList;

                    string data = result.Content.ReadAsStringAsync().Result;
                    room = JsonConvert.DeserializeObject<RoomVM>(data);
                    return View(room);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }

                
            
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRoom(RoomVM model)
        {
                if (ModelState.IsValid)
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    var result = await _client.UpdateRoom(request, model);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("RoomList");
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

        public async Task<IActionResult> DeleteRoom(int id)
        {
            string token = HttpContext.Session.GetString("AccessToken");
            if (token == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                var room = await _client.GetRoomById(id,token);
                if (room != null)
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    var result = await _client.DeleteRoom(id,token);
                    if (result.IsSuccessStatusCode)
                    {

                        return RedirectToAction("RoomList");
                    }
                    else
                    {
                        return RedirectToAction("Error", "Home");
                    }

                }
                else
                {
                    return RedirectToAction("RoomList");
                }
            }
             
        }

    }
}
