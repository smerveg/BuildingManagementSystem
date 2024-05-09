using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.Entities
{
    public class ProductStorage
    {
        public int ProductStorageID { get; set; }
        public int ProductID { get; set; }
        public int StorageID { get; set; }
        public int Quantity { get; set; }
    }
}
