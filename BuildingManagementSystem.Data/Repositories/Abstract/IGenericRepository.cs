using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.Repositories.Abstract
{
    public interface IGenericRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
    }
}
