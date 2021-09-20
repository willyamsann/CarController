using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPi.Controllers
{
 
        [Route("api/[controller]")]
        [ApiController]
        public class DriverController : ControllerBase
        {
            private IGenericService<Driver> _baseDriverService;
            private IDriverService _driverService;


            public DriverController(IGenericService<Driver> baseDriverService, 
                IDriverService driverService)
            {
            _baseDriverService = baseDriverService;
            _driverService = driverService;
            }

            [HttpPost]
            public IActionResult Create([FromBody] Driver driver)
            {
                if (driver == null)
                    return NotFound();

                return Execute(() => _baseDriverService.Add<DriverValidator>(driver).Id);
            }

            [HttpPut]
            public IActionResult Update([FromBody] Driver driver)
            {
                if (driver == null)
                    return NotFound();

                return Execute(() => _baseDriverService.Update<DriverValidator>(driver));
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                if (id == 0)
                    return NotFound();

                Execute(() =>
                {
                    _baseDriverService.Delete(id);
                    return true;
                });

                return new NoContentResult();
            }

            [HttpGet]
            public IActionResult Get()
            {
                return Execute(() => _baseDriverService.Get());
            }

            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                if (id == 0)
                    return NotFound();

                return Execute(() => _baseDriverService.GetById(id));
            }

            [HttpGet]
            [Route("SearchByName")]
            public IActionResult SearchResultsByName(string name)
            {
                if (name == null)
                    return NotFound();

                return Execute(() => _driverService.SearchByName(name));
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
