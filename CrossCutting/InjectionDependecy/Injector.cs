using Data.Repository;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services.Interface;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.InjectionDependecy
{
    public static class Injector
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ICarService), typeof(CarService));
            services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
            services.AddScoped(typeof(IDriverService), typeof(DriverService));
            services.AddScoped(typeof(IDriverRepository), typeof(DriverRepository));
            services.AddScoped(typeof(ICarUseService), typeof(CarUseService));
            services.AddScoped(typeof(ICarUseRepository), typeof(CarUseRepository));

        }
    }
}
