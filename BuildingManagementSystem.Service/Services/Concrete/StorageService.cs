using BuildingManagementSystem.Data.Entities;
using BuildingManagementSystem.Data.Repositories.Abstract;
using BuildingManagementSystem.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Service.Services.Concrete
{
    public class StorageService:IStorageService
    {
        private readonly IStorageRepository _repository;
        public StorageService(IStorageRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Storage>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<Storage> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<bool> Add(Storage entity)
        {
            var result = await _repository.Add(entity);
            if (result > 0)
            {
                return true;
            }
            else
                return false;
        }
        public async Task<bool> Update(Storage entity)
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
