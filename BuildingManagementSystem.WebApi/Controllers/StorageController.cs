using AutoMapper;
using BuildingManagementSystem.Data.DTOs.Storage;
using BuildingManagementSystem.Data.Entities;
using BuildingManagementSystem.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _service;
        private readonly IBuildingService _buildingService;
        private readonly IMapper _mapper;

        public StorageController(IStorageService service,IBuildingService buildingService, IMapper mapper)
        {
            _service = service;
            _buildingService = buildingService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var storageList = await _service.GetAll();
            if (storageList == null)
            {
                throw new Exception();
            }
            else
            {
                var result = _mapper.Map<List<StorageDTO>>(storageList);
                foreach (var item in result)
                {

                    var buildingName = await _buildingService.GetById(item.BuildingID);
                    item.BuildingName = buildingName.Name;

                }
                return Ok(result);
            }

        }
        [HttpGet("storageDetail/{id}")]
        public async Task<IActionResult> StorageDetail(int id)
        {
            var storage = await _service.GetById(id);
            if (storage == null)
            {
                throw new Exception();
            }
            else
            {
                var result = _mapper.Map<Storage, StorageDTO>(storage);
                return Ok(result);
            }
        }
        [HttpPost]
        [Route("addStorage")]
        public async Task<IActionResult> Add(Storage entity)
        {
            var storage = await _service.Add(entity);
            if (!storage)
            {
                throw new Exception();
            }
            else
            {
                var result = _mapper.Map<Storage, StorageDTO>(entity);
                return Ok(result);
            }
        }
        [HttpPut]
        [Route("updateStorage")]
        public async Task<IActionResult> Update(Storage entity)
        {
            var storage = await _service.Update(entity);
            if (!storage)
            {
                throw new Exception();
            }
            else
            {
                var result = _mapper.Map<Storage, StorageDTO>(entity);
                return Ok(result);
            }
        }
        [HttpDelete("deleteStorage/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var storage = await _service.Delete(id);
            if (!storage)
            {
                throw new Exception();
            }
            else
                return Ok();
        }

    }
}
