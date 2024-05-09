using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingManagementSystem.Data.Repositories.Abstract;
using BuildingManagementSystem.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagementSystem.Data.Repositories.Concrete
{
    public class GenericRepository<T>:IGenericRepository<T> where T: class
    {
        private readonly BMSContext _context;
        public GenericRepository(BMSContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<int> Add(T entity)
        {
            var newEntity = _context.Add(entity);
            return await _context.SaveChangesAsync();
            
        }
        public async Task<int> Update(T entity)
        {
             _context.Update(entity);
            return await _context.SaveChangesAsync();
            
        }
        public async Task<int> Delete(int id)
        {
            var entity= _context.Set<T>().Find(id);
            _context.Remove(entity);
            return await  _context.SaveChangesAsync();
        }
    }
}
