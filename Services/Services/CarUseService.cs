using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using Services.Interface;
using Services.Validator;
using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CarUseService : ICarUseService
    {
        private readonly ICarUseRepository _carUseRepository;
        private readonly IGenericRepository<CarUse> _baseRepository;
        private readonly IMapper _mapper;

        public CarUseService(ICarUseRepository carUseRepository, IGenericRepository<CarUse> baseRepository,IMapper mapper)
        {
            _carUseRepository = carUseRepository;
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public CarUseViewModel CreateRegister(CarUseViewModel objViewModel)
        {
            var obj = _mapper.Map<CarUse>(objViewModel);
            Validate(obj, Activator.CreateInstance<CarUseValidator>());
            obj.DateStart = DateTime.Now;
            obj.Finished = false;
            _baseRepository.Insert(obj);
            return objViewModel;
        }

        public CarUseViewModel Finished(int id)
        {
            var obj = _carUseRepository.GetById(id);
            if (obj.Finished)
                return null;
            obj.Finished = true;
            obj.DateEnd = DateTime.Now;
            _baseRepository.Update(obj);

            var objViewModel = _mapper.Map<CarUseViewModel>(obj);
            return objViewModel;
        }

        public IEnumerable<CarUseViewModel> GetAll()
        {
            var objs = _carUseRepository.GetAll();
            return _mapper.Map<IEnumerable<CarUseViewModel>>(objs);
        }

        public CarUseViewModel GetById(int id)
        {
            var obj = _carUseRepository.GetById(id);
            return _mapper.Map<CarUseViewModel>(obj);
        }

        public CarUseViewModel GetByDriverId(int idDriver)
        {
            var obj = _carUseRepository.GetByDriverId(idDriver);
            return _mapper.Map<CarUseViewModel>(obj);
        }

        private void Validate(CarUse obj, AbstractValidator<CarUse> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
