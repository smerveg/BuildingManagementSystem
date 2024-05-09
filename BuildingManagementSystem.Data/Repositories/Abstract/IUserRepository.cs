using BuildingManagementSystem.Data.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task<string> GenerateToken(UserDTO userInfo);
    }
}
