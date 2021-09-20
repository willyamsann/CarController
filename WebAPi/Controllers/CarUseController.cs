using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Validator;
using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPi.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class CarUseController : ControllerBase
        {
            private IGenericService<CarUse> _baseCarService;
            private ICarUseService _carUseService;


            public CarUseController(IGenericService<CarUse> baseCarService,
                ICarUseService carUseService)
            {
                _baseCarService = baseCarService;
                    _carUseService = carUseService;
            }

            [HttpPost]
            public IActionResult Create([FromBody] CarUseViewModel carUse)
            {
                if (carUse == null)
                    return NotFound();
                 var verificaded = _carUseService.GetByDriverId(carUse.DriverId);

                if(verificaded != null)
                    return  BadRequest(error: "Motorista já cadastrado  nome: "+ verificaded.Driver.Name);

               var obj = _carUseService.CreateRegister(carUse);
                
                return Ok(obj);
            }

            [HttpPut]
            public IActionResult Update([FromBody] CarUse car)
            {
                if (car == null)
                    return NotFound();

                return Execute(() => _baseCarService.Update<CarUseValidator>(car));
            }

            [HttpGet]
            [Route("finished")]
            public IActionResult Finished(int id)
            {
            var finished = _carUseService.Finished(id);
                    if (finished != null)
                    {
                        return Ok(finished);
                    }
                    else
                    {
                        return BadRequest(error: "Já finalizado");
                    }
            }

           
            [HttpGet]
            public IActionResult Get()
            {
                return Execute(() => _carUseService.GetAll());
            }

            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                if (id == 0)
                    return NotFound();

                return Execute(() => _carUseService.GetById(id));
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
