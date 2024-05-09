using BuildingManagementSystem.Data.DTOs.User;
using BuildingManagementSystem.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("generateToken")]
        public async Task<string> GenerateToken(UserDTO userInfo)
        {
            return await _service.GenerateToken(userInfo);
        }
    }
}
