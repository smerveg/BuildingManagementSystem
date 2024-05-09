using BuildingManagementSystem.Data.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Service.Services.Abstract
{
    public interface IUserService
    {
        Task<string> GenerateToken(UserDTO userInfo);
    }
}
