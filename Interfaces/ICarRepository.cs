using MinimalApiCrud.Models;

namespace MinimalApiCrud.Interfaces
{
    public interface ICarRepository
    {
         IEnumerable<CarModel> GetCars();
         bool InsertCar(CarModel car);
         bool UpdateCarCor(string cor, int id);
         bool Delete(int id);

    }
}
