using LoggingLibSample;
using Microsoft.AspNet.Mvc;

namespace LoggingSample.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsContext _carsContext;

        public CarsController(CarsContext carsContext)
        {
            _carsContext = carsContext;
        }

        [Route("cars")]
        public IActionResult Get()
        {
            var cars = _carsContext.GetCars();
            return Ok(cars);
        }
    }
}