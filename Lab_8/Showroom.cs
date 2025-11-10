using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Showroom
    {
        private List<Car> _cars = new List<Car>();

        public string Name { get; private set; }
        public int CarCount => _cars.Count;
        public int AvailableCarCount => _cars.Count(c => c.IsAvailable);

        public Showroom(string name)
        {
            Name = name;
        }

        public void AddCar(Car car)
        {
            if (car == null)
                throw new ArgumentNullException(nameof(car));

            if (car.Year < 2000 || car.Year > DateTime.Now.Year + 1)
                throw new ArgumentException("Invalid car year");

            _cars.Add(car);
        }

        public bool RemoveCar(string brand, string model)
        {
            var car = _cars.FirstOrDefault(c =>
                c.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
                c.Model.Equals(model, StringComparison.OrdinalIgnoreCase));

            if (car != null)
            {
                _cars.Remove(car);
                return true;
            }
            return false;
        }

        public Car SellCar(string brand, string model)
        {
            var car = _cars.FirstOrDefault(c =>
                c.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
                c.Model.Equals(model, StringComparison.OrdinalIgnoreCase) &&
                c.IsAvailable);

            if (car != null)
            {
                car.IsAvailable = false;
                return car;
            }
            return null;
        }

        public IEnumerable<Car> GetAvailableCars()
        {
            return _cars.Where(c => c.IsAvailable);
        }

        public IEnumerable<Car> GetCarsByBrand(string brand)
        {
            return _cars.Where(c =>
                c.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase));
        }

        public decimal CalculateTotalValue()
        {
            return _cars.Where(c => c.IsAvailable).Sum(c => c.Price);
        }

        public Car FindCheapestCar()
        {
            return _cars.Where(c => c.IsAvailable).OrderBy(c => c.Price).FirstOrDefault();
        }

        public Car FindMostExpensiveCar()
        {
            return _cars.Where(c => c.IsAvailable).OrderByDescending(c => c.Price).FirstOrDefault();
        }
    }
}
