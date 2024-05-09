using BuildingManagementSystem.Data.Context;
using BuildingManagementSystem.Data.DTOs.Product;
using BuildingManagementSystem.Data.DTOs.Storage;
using BuildingManagementSystem.Data.Entities;
using BuildingManagementSystem.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.Repositories.Concrete
{
    public class ProductRepository: GenericRepository<Product>,IProductRepository
    {
        private readonly BMSContext _context;
        public ProductRepository(BMSContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll2()
        {
            var query = (from p in _context.Products
                         join ps in _context.ProductStorages on p.ProductID equals ps.ProductID
                         join s in _context.Storages on ps.StorageID equals s.StorageID
                         select new ProductDTO
                         {
                             Name = p.Name,
                             Description = p.Description,
                             StorageName = s.Name,
                             Quantity = ps.Quantity
                         }).ToListAsync();
            return await query;
        }
    }
}
