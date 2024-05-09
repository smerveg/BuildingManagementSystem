using BuildingManagementSystem.Data.Context;
using BuildingManagementSystem.Data.Repositories.Abstract;
using BuildingManagementSystem.Data.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagementSystem.Data.Extension
{
    public static class DataExtension
    {
        public static IServiceCollection AddDataExtension(this IServiceCollection service,
            IConfiguration config)
        {
            service.AddScoped<IBuildingRepository, BuildingRepository>();
            service.AddScoped<IRoomRepository, RoomRepository>();
            service.AddScoped<IStorageRepository, StorageRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddDbContext<BMSContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return service;
        }
    }
}
