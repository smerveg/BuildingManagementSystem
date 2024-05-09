using AutoMapper;
using BuildingManagementSystem.Data.Context;
using BuildingManagementSystem.Data.DTOs.Product;
using BuildingManagementSystem.Data.DTOs.Storage;
using BuildingManagementSystem.Data.Entities;
using BuildingManagementSystem.Data.Repositories.Abstract;
using BuildingManagementSystem.Service.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Service.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly BMSContext _context;

        public ProductService(IProductRepository repository,IMapper mapper,BMSContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
                
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _repository.GetAll();
            
        }
        public async Task<IEnumerable<ProductDTO>> GetAll2()
        {
            return await _repository.GetAll2();
        }
        public async Task<Product> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<bool> Add(Product entity)
        {
            var result = await _repository.Add(entity);
            if (result > 0)
            {
                return true;
            }
            else
                return false;
        }
        public async Task<bool> Update(Product entity)
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
        public int AddProduct(Product entity)
        {           
            var result = _context.Entry(entity);
            result.State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            int productId = entity.ProductID;
            return productId;
        }

        public int AddProductStorage(int ProductId, List<StorageDTO> storageList)
        {
            List<ProductStorage> list = new List<ProductStorage>();
            foreach (var item in storageList)
            {
                ProductStorage pb = new ProductStorage()
                {
                    StorageID = item.StorageID,
                    ProductID = ProductId,
                    Quantity = item.Quantity

                };

                list.Add(pb);

            }
            _context.ProductStorages.AddRange(list);
            return _context.SaveChanges();




        }

    }
}
