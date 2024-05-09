using BuildingManagementSystem.Data.Entities;
using BuildingManagementSystem.Data.Repositories.Abstract;
using BuildingManagementSystem.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagementSystem.Service.Services.Concrete
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Room>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<Room> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<bool> Add(Room entity)
        {
            var result = await _repository.Add(entity);
            if (result > 0)
            {
                return true;
            }
            else
                return false;
        }
        public async Task<bool> Update(Room entity)
        {
            var result = await _repository.Update(entity);
            if (result > 0)
            {
                return true;
            }
            else
                return false;

        }
        public async Task<bool> Delete(int id)
        {
            var result = await _repository.Delete(id);
            if (result > 0)
            {
                return true;
            }
            else
                return false;

        }
    }
}
