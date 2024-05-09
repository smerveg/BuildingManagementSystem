using BuildingManagementSystem.Data.DTOs.Product;
using BuildingManagementSystem.Data.DTOs.Storage;
using BuildingManagementSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.Repositories.Abstract
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<IEnumerable<ProductDTO>> GetAll2();
    }
}
