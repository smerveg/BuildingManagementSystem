using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.Entities
{
    public class Room
    {
        public int RoomID { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public string Properties { get; set; }

        //

        public int BuildingID { get; set; }
        public Building Building { get; set; }

    }
}
