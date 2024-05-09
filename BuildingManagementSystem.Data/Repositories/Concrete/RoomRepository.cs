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
    public class RoomRepository:GenericRepository<Room>,IRoomRepository
    {
        public RoomRepository(BMSContext context) : base(context)
        {

        }
    }
}
