using AutoMapper;
using BuildingManagementSystem.Data.DTOs.Product;
using BuildingManagementSystem.Data.Entities;
using BuildingManagementSystem.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, IStorageService storageService, IMapper mapper)
        {
            _service = service;
            _storageService = storageService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            //var deneme = await _service.GetAll();
            var productList = await _service.GetAll2();
            if (productList == null)
            {
                throw new Exception();
            }
            else
            {
                //var result = _mapper.Map<List<ProductDTO>>(productList);
                return Ok(productList);
            }

        }
        [HttpGet("ProductDetail/{id}")]
        public async Task<IActionResult> ProductDetail(int id)
        {
            var product = await _service.GetById(id);
            if (product == null)
            {
                throw new Exception();
            }
            else
            {
                var result = _mapper.Map<Product, ProductDTO>(product);
                return Ok(result);
            }
        }
        [HttpPost]
        [Route("addProduct")]
        public async Task<IActionResult> Add(ProductDTO entity)
        {
            var product = _mapper.Map<ProductDTO, Product>(entity);
            var id = _service.AddProduct(product);
            if (id ==0)
            {
                throw new Exception();
            }

            else
            {
                _service.AddProductStorage(id, entity.Storages);
                return Ok(product);
            }
        }
        [HttpPut]
        [Route("updateProduct")]
        public async Task<IActionResult> Update(ProductDTO entity)
        {
            var product = _mapper.Map<ProductDTO, Product>(entity);
            var result = await _service.Update(product);
            if (!result)
            {

                throw new Exception();
            }
            else
                return Ok(entity);
        }
        [HttpDelete("deleteProduct/{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.Delete(id);
            if (!product)
            {
                throw new Exception();
            }
            else
                return Ok();
        }

    }
}
