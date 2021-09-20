using AutoMapper;
using Domain.Entities;
using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AutoMapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
            => CreateMap<Car, CarViewModel>().ReverseMap();
    }
}
