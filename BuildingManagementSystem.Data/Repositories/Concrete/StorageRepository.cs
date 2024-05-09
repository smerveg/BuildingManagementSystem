using BuildingManagementSystem.Data.Context;
using BuildingManagementSystem.Data.Entities;
using BuildingManagementSystem.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.Repositories.Concrete
{
    public class StorageRepository : GenericRepository<Storage>, IStorageRepository
    {
        public StorageRepository(BMSContext context) : base(context)
        {

        }
    }
}

