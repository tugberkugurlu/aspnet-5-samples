using System.Collections.Generic;

namespace TestingSample
{
    public class CarsRepository 
    {
        public IEnumerable<string> GetCars() 
        {
            return new[]
            {
                "Cars 1",
                "Cars 2",
                "Cars 3"
            };
        }
    }
}