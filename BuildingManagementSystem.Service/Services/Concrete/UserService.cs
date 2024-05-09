using BuildingManagementSystem.Data.DTOs.User;
using BuildingManagementSystem.Data.Repositories.Abstract;
using BuildingManagementSystem.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Service.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> GenerateToken(UserDTO userInfo)
        {
            return await _repository.GenerateToken(userInfo);
        }
    }
}
