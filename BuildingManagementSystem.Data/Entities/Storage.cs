using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.Entities
{
    public class Storage
    {
        public int StorageID { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public string Properties { get; set; }

        //

        public int BuildingID { get; set; }
        public Building Building { get; set; }
        public ICollection<Product> Products { get; set; } = null;
        public ICollection<ProductStorage> ProductStorages { get; set; }
    }
}
