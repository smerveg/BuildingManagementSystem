using AutoMapper;
using BuildingManagementSystem.Data.DTOs.Building;
using BuildingManagementSystem.Data.Entities;
using BuildingManagementSystem.Service.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
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
   
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _service;
        private readonly IMapper _mapper;

        public BuildingController(IBuildingService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var buildingList = await _service.GetAll();
            if (buildingList == null)
            {
                throw new Exception();
            }
            else
            {
                var result = _mapper.Map<List<BuildingDTO>>(buildingList);
                return Ok(result);
            }
            
        }
        [HttpGet("buildingDetail/{id}")]
        public async Task<IActionResult> BuildingDetail(int id)
        {
            var building= await _service.GetById(id);
            if (building==null)
            {
                throw new Exception();
            }
            else
            {
                var result = _mapper.Map<Building,BuildingDTO>(building);
                return Ok(result);
            }
        }
      
        [HttpPost]
        [Route("addBuilding")]
        
        public async Task<IActionResult> Add(Building entity)
        {
            var building =await _service.Add(entity);
            if (!building)
            {
                throw new Exception();
                
            }
            else
            {
                var result = _mapper.Map<Building, BuildingDTO>(entity);
                return Ok(result);
            }
                
        }
        [HttpPut]
        [Route("updateBuilding")]
        public async Task<IActionResult> Update(Building entity)
        {
            var building = await _service.Update(entity);
            if (!building)
            {
                throw new Exception();
                
            }
            else
            {
                var result = _mapper.Map<Building, BuildingDTO>(entity);
                return Ok(result);
            }
                
        }
        [HttpDelete("deleteBuilding/{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var building = await _service.Delete(id);
            if (!building)
            {
                throw new Exception();
            }
            else
            {
                
                return Ok();
            }
                
        }
    }
}
