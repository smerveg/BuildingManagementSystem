using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingManagementSystem.Service.Services.Abstract;
using BuildingManagementSystem.Data.Repositories.Abstract;
using BuildingManagementSystem.Data.Entities;

namespace BuildingManagementSystem.Service.Services.Concrete
{
    public class BuildingService:IBuildingService
    {
        private readonly IBuildingRepository _repository;
        public BuildingService(IBuildingRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Building>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<Building> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<bool> Add(Building entity)
        {
             var result=await _repository.Add(entity);
            if (result > 0)
            {
                return true;
            }
            else
                return false;
        }
        public async Task<bool> Update(Building entity)
        {
             var result=await _repository.Update(entity);
            if (result > 0)
            {
                return true;
            }
            else
                return false;

        }
        public async Task<bool> Delete(int id)
        {
            var result=await _repository.Delete(id);
            if (result > 0)
            {
                return true;
            }
            else
                return false;

        }

    }
}
