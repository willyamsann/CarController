using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Validator;
using System;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private IGenericService<Car> _baseCarService;
        private ICarService _carService;


        public CarController(IGenericService<Car> baseCarService,
            ICarService carService)
        {
            _baseCarService = baseCarService;
            _carService = carService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Car car)
        {
            if (car == null)
                return NotFound();

            return Execute(() => _baseCarService.Add<CarValidator>(car).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Car car)
        {
            if (car == null)
                return NotFound();

            return Execute(() => _baseCarService.Update<CarValidator>(car));
        }

        [HttpGet]
        [Route("SearchByFilter")]
        public IActionResult SearchResultsByFilter(string color,string brand)
        {

            return Execute(() => _carService.SearchByFilter(color,brand));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseCarService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseCarService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseCarService.GetById(id));
        }

  
        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
