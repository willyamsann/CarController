using AutoMapper;
using Domain.Entities;
using Services.ViewModel;

namespace Services.AutoMapper
{
    public class CarUseProfile : Profile
    {
        public CarUseProfile()
            => CreateMap<CarUse, CarUseViewModel>().ReverseMap();
    }
}
