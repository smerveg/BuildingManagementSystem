using BuildingManagementSystem.Data.DTOs.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.DTOs.Product
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<StorageDTO> Storages { get; set; }
        public int Quantity { get; set; }
        public string StorageName { get; set; }
    }
}
