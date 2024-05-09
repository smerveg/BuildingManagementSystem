using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingManagementSystem.Data.Entities;
using BuildingManagementSystem.Data.Repositories.Abstract;
using BuildingManagementSystem.Data.Context;

namespace BuildingManagementSystem.Data.Repositories.Concrete
{
    public class BuildingRepository:GenericRepository<Building>,IBuildingRepository
    {

        public BuildingRepository(BMSContext context):base(context)
        {

        }

    }
}
