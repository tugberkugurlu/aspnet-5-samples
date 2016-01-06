using System.Linq;
using Xunit;

namespace TestingSample.Tests
{
    public class CarsRepositoryTests 
    {
        [Fact]
        public void GetCars_Should_Not_Return_Null()
        {
            var repo = new CarsRepository();
            var cars = repo.GetCars();
            Assert.NotNull(cars);
        }
        
        [Fact]
        public void GetCars_Should_Return_4_Items()
        {
            var repo = new CarsRepository();
            var cars = repo.GetCars();
            Assert.Equal(4, cars.Count());
        }
    }   
}