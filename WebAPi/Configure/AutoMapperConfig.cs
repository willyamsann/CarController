﻿using Microsoft.Extensions.DependencyInjection;
using Services.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebAPi.Configure
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
            => services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperProfiles)));
    }
}
