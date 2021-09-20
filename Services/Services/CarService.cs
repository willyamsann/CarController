using AutoMapper;
using Domain.Interfaces;
using Services.Interface;
using Services.ViewModel;
using System.Collections.Generic;

namespace Services.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }


        public IEnumerable<CarViewModel> SearchByFilter(string color,string brand)
        {
            var obj = _carRepository.SearchByFilter(color,brand);
            var objviewmodel = _mapper.Map<IEnumerable<CarViewModel>>(obj);
            return objviewmodel;
        }
    }
}
