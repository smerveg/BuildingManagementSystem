using BuildingManagementSystem.Data.DTOs.Product;
using BuildingManagementSystem.Data.DTOs.Storage;
using BuildingManagementSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Service.Services.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        int AddProduct(Product entity);
        int AddProductStorage(int ProductId,List<StorageDTO> storageList);
        Task<IEnumerable<ProductDTO>> GetAll2();

    }
}
