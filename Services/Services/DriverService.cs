using AutoMapper;
using Domain.Interfaces;
using Services.Interface;
using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public DriverService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }


        public IEnumerable<DriverViewModel> SearchByName(string name)
        {
            var obj = _driverRepository.SearchByName(name);
            var objviewmodel = _mapper.Map<IEnumerable<DriverViewModel>>(obj);
            return objviewmodel;
        }
    }   
}
