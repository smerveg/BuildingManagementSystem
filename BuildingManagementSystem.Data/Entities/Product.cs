﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //
        public ICollection<Storage> Storages { get; set; } = null;
        public ICollection<ProductStorage> ProductStorages { get; set; }
    }
}
