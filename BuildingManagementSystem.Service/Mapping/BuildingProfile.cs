using AutoMapper;
using BuildingManagementSystem.Data.DTOs.Building;
using BuildingManagementSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Service.Mapping
{
    public class BuildingProfile:Profile
    {
        public BuildingProfile()
        {
            CreateMap<Building, BuildingDTO>().ReverseMap();
           
        }
    }
}
