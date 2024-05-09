using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.DTOs.Room
{
    public class RoomDTO
    {
        public int RoomID { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public string Properties { get; set; }
        public int BuildingID { get; set; }
        public string BuildingName { get; set; }
    }
}
