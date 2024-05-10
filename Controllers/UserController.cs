using BuildingManagementSystem.ConsumeApi.Clients.Abstract;
using BuildingManagementSystem.ConsumeApi.Models.UserViewModel;
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
    public class UserController : Controller
    {
        private readonly IUserClient _client;

        public UserController(IUserClient client)
        {
            _client = client;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserVM model)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            if (ModelState.IsValid)
            {
                var token = await _client.GenerateToken(model);
                if (token!=null)
                {
                    HttpContext.Session.SetString("AccessToken", token);
                    return RedirectToAction("Index", "Home");
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
