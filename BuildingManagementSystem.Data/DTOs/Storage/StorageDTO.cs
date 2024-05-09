using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.DTOs.Storage
{
    public class StorageDTO
    {
        public int StorageID { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public int Quantity { get; set; }
        public string Properties { get; set; }
        public int BuildingID { get; set; }
        public string BuildingName { get; set; }
    }
}
