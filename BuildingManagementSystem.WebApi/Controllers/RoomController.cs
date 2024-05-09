using AutoMapper;
using BuildingManagementSystem.Data.DTOs.Room;
using BuildingManagementSystem.Data.Entities;
using BuildingManagementSystem.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;
        private readonly IBuildingService _buildingService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService service,IBuildingService buildingService, IMapper mapper)
        {
            _service = service;
            _buildingService = buildingService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var roomList = await _service.GetAll();
            if (roomList == null)
            {
                throw new Exception();
            }
            else
            {
                var result = _mapper.Map<List<RoomDTO>>(roomList);
                foreach (var item in result)
                {

                    var buildingName=await  _buildingService.GetById(item.BuildingID);
                    item.BuildingName = buildingName.Name;
                    
                }
                return Ok(result);
            }

        }
        [HttpGet("roomDetail/{id}")]
        public async Task<IActionResult> RoomDetail(int id)
        {
            var room = await _service.GetById(id);
            if (room == null)
            {
                throw new Exception();
            }
            else
            {
                var result = _mapper.Map<Room, RoomDTO>(room);
                return Ok(result);
            }
        }
        [HttpPost]
        [Route("addRoom")]
        public async Task<IActionResult> Add(Room entity)
        {
            var room = await _service.Add(entity);
            if (!room)
            {
                throw new Exception();
            }
            else
            {
                var result = _mapper.Map<Room, RoomDTO>(entity);
                return Ok(result);
            }
        }
        [HttpPut]
        [Route("updateRoom")]
        public async Task<IActionResult> Update(Room entity)
        {
            var room = await _service.Update(entity);
            if (!room)
            {
                throw new Exception();
            }
            else
            {
                var result = _mapper.Map<Room, RoomDTO>(entity);
                return Ok(result);
            }
        }
        [HttpDelete("deleteRoom/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var room = await _service.Delete(id);
            if (!room)
            {
                throw new Exception();
            }
            else
                return Ok();
        }

    }
}
