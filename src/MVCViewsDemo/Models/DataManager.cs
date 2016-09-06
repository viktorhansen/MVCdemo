using MVCViewsDemo.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCViewsDemo.Models
{
    public class DataManager
    {
        private static CarsContext _context;
        public DataManager(CarsContext context)
        {
            _context = context;
        }

        public void AddCar(CreateCarViewModel viewModel)
        {
            _context.Cars.Add(new Car {
                Brand = viewModel.Brand, Doors = viewModel.Doors,
                TopSpeed = viewModel.TopSpeed
            });

            _context.SaveChanges();
        }

        public ListCarViewModel[] GetCars()
        {
            return _context.Cars.Select(c => CarToListCarViewModel(c)).ToArray();
        }

        public ListCarViewModel CarToListCarViewModel(Car car)
        {
            return new ListCarViewModel
            {
                Brand = car.Brand,
                ShowAsFast = car.TopSpeed > 250,
                Id = car.Id
            };
        }

        internal void UpdateCar(UpdateCarVM viewModel)
        {
            var carToUpdate =_context.Cars.SingleOrDefault(c => c.Id == viewModel.Id);
            carToUpdate.Brand = viewModel.Brand;
            carToUpdate.Doors = viewModel.Doors;
            carToUpdate.TopSpeed = viewModel.TopSpeed;
            _context.SaveChanges();

        }

        public void RemoveCar(int id)
        {
            var carToRemove = _context.Cars.Where(c => c.Id == id).SingleOrDefault();
            _context.Cars.Remove(carToRemove);
            _context.SaveChanges();
        }

        internal UpdateCarVM GetSingleCar(int id)
        {
            return _context.Cars.Where(c => c.Id == id).Select(c => new UpdateCarVM {
                Brand = c.Brand,
                Doors = c.Doors,
                TopSpeed = c.TopSpeed,
                Id = c.Id
            }).SingleOrDefault();
        }
    }
}
