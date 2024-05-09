using AutoMapper;
using BuildingManagementSystem.Data.DTOs.Storage;
using BuildingManagementSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Service.Mapping
{
    public class StorageProfile : Profile
    {
        public StorageProfile()
        {
            CreateMap<Storage, StorageDTO>().ReverseMap();

        }
    }
}
