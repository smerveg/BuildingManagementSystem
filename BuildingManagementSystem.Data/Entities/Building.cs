using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.Entities
{
    public class Building
    {
        public int BuildingID { get; set; }
        public string Name { get; set; }
        public string Properties { get; set; }

        //

        public ICollection<Room> Rooms { get; set; } = null;
        public ICollection<Storage> Storages { get; set; } = null;
    }
}
