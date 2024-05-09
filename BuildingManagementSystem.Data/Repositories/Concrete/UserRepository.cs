using BuildingManagementSystem.Data.Context;
using BuildingManagementSystem.Data.DTOs.User;
using BuildingManagementSystem.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly BMSContext _context;
        private readonly IConfiguration _config;
        public UserRepository(IConfiguration config,BMSContext context)
        {
            _context = context;
            _config = config;
        }
        public async Task<string> GenerateToken(UserDTO userInfo)
        {
            string token = null;
            if (userInfo.UserName != null && userInfo.Password != null)
            {
                var user = await GetUser(userInfo.UserName, userInfo.Password);

                if (user != null)
                {
                    SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["AppSettings:Secret"]));

                    JwtSecurityToken jwt = new JwtSecurityToken(
                            issuer: _config["AppSettings:ValidIssuer"],
                            audience: _config["AppSettings:ValidAudience"],
                            claims: new List<Claim> {
                            new Claim("userName", user.UserName),
                            new Claim("password", user.Password),
                            

                            },

                            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                        );
                     token=  new JwtSecurityTokenHandler().WriteToken(jwt);
                    
                }
                
            }
            return token;

        }

        private async Task<UserDTO> GetUser(string userName, string password)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
            UserDTO userDTO = new UserDTO();
            if (result != null)
            {

                userDTO.UserName = result.UserName;
                userDTO.Password = result.Password;

                return userDTO;
            }
            else
                return userDTO;


        }
    }
}
