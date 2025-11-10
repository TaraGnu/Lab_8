using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } = true;

        public Car(string brand, string model, int year, decimal price)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Brand} {Model} ({Year}) - {Price:C} {(IsAvailable ? "✓" : "✗")}";
        }
    }
}
