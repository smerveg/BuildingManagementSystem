using BuildingManagementSystem.Service.Services.Abstract;
using BuildingManagementSystem.Service.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using RoomManagementSystem.Service.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Service.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServiceExtension(this IServiceCollection service)
        {
            service.AddScoped<IBuildingService, BuildingService>();
            service.AddScoped<IRoomService, RoomService>();
            service.AddScoped<IStorageService, StorageService>();
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<IUserService, UserService>();
            var assembly = Assembly.GetExecutingAssembly();
            service.AddAutoMapper(assembly);
            return service;
        }
    }
}
