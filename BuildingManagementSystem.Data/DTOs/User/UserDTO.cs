using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.DTOs.User
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
