using BuildingManagementSystem.ConsumeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManagementSystem.ConsumeApi.Controllers
{
    public class HomeController : Controller
    {       

        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("AccessToken");
            if (token == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else

            return View();
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
