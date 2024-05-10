using BuildingManagementSystem.ConsumeApi.Models.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuildingManagementSystem.ConsumeApi.Clients.Abstract
{
    public interface IUserClient
    {
        Task<string> GenerateToken(UserVM model);
    }
}
