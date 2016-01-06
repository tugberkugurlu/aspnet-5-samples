using System.Collections.Generic;
using Microsoft.AspNet.Mvc;

namespace TestingSample.Controllers
{
    [Route("cars")]
    public class CarsController : Controller 
    {
        private readonly CarsRepository _repo;
        
        public CarsController(CarsRepository repo)
        {
            if (repo == null)
            {
                throw new System.ArgumentNullException(nameof(repo));   
            }
            
            _repo = repo;
        }
        
        [HttpGet]
        public IEnumerable<string> Get() 
        {
            return _repo.GetCars();
        }
    }
}