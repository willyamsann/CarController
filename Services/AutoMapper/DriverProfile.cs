using AutoMapper;
using Domain.Entities;
using Services.ViewModel;

namespace Services.AutoMapper
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
            => CreateMap<Driver, DriverViewModel>().ReverseMap();
    }
}
