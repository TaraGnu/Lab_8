using Lab_8;
namespace Showroom.Test
{
        public class ShowroomTests
        {
            [Fact]
            public void AddCar_ValidCar_ShouldIncreaseCount()
            {
                // Arrange
                var showroom = new Showroom("Test Showroom");
                var car = new Car("Toyota", "Camry", 2022, 25000);

                // Act
                showroom.AddCar(car);

                // Assert
                Assert.Equal(1, showroom.CarCount);
                Assert.Equal(1, showroom.AvailableCarCount);
            }

            [Fact]
            public void AddCar_NullCar_ShouldThrowException()
            {
                // Arrange
                var showroom = new Showroom("Test Showroom");

                // Act & Assert
                Assert.Throws<ArgumentNullException>(() => showroom.AddCar(null));
            }

            [Fact]
            public void AddCar_InvalidYear_ShouldThrowException()
            {
                // Arrange
                var showroom = new Showroom("Test Showroom");
                var car = new Car("Toyota", "Camry", 1990, 25000);

                // Act & Assert
                Assert.Throws<ArgumentException>(() => showroom.AddCar(car));
            }

            [Fact]
            public void SellCar_AvailableCar_ShouldMarkAsSold()
            {
                // Arrange
                var showroom = new Showroom("Test Showroom");
                var car = new Car("Toyota", "Camry", 2022, 25000);
                showroom.AddCar(car);

                // Act
                var soldCar = showroom.SellCar("Toyota", "Camry");

                // Assert
                Assert.NotNull(soldCar);
                Assert.False(soldCar.IsAvailable);
                Assert.Equal(0, showroom.AvailableCarCount);
                Assert.Equal(1, showroom.CarCount);
            }

            [Fact]
            public void SellCar_NonExistentCar_ShouldReturnNull()
            {
                // Arrange
                var showroom = new Showroom("Test Showroom");

                // Act
                var soldCar = showroom.SellCar("Toyota", "Camry");

                // Assert
                Assert.Null(soldCar);
            }

            [Fact]
            public void RemoveCar_ExistingCar_ShouldRemoveFromList()
            {
                // Arrange
                var showroom = new Showroom("Test Showroom");
                var car = new Car("Toyota", "Camry", 2022, 25000);
                showroom.AddCar(car);

                // Act
                var result = showroom.RemoveCar("Toyota", "Camry");

                // Assert
                Assert.True(result);
                Assert.Equal(0, showroom.CarCount);
            }

            [Fact]
            public void CalculateTotalValue_WithCars_ShouldReturnCorrectSum()
            {
                // Arrange
                var showroom = new Showroom("Test Showroom");
                showroom.AddCar(new Car("Toyota", "Camry", 2022, 25000));
                showroom.AddCar(new Car("Honda", "Civic", 2021, 22000));

                // Act
                var totalValue = showroom.CalculateTotalValue();

                // Assert
                Assert.Equal(47000, totalValue);
            }

            [Fact]
            public void FindCheapestCar_WithMultipleCars_ShouldReturnCheapest()
            {
                // Arrange
                var showroom = new Showroom("Test Showroom");
                showroom.AddCar(new Car("Toyota", "Camry", 2022, 25000));
                showroom.AddCar(new Car("Honda", "Civic", 2021, 22000));
                showroom.AddCar(new Car("BMW", "X5", 2023, 60000));

                // Act
                var cheapestCar = showroom.FindCheapestCar();

                // Assert
                Assert.NotNull(cheapestCar);
                Assert.Equal("Honda", cheapestCar.Brand);
                Assert.Equal(22000, cheapestCar.Price);
            }

            [Fact]
            public void FindMostExpensiveCar_WithMultipleCars_ShouldReturnMostExpensive()
            {
                // Arrange
                var showroom = new Showroom("Test Showroom");
                showroom.AddCar(new Car("Toyota", "Camry", 2022, 25000));
                showroom.AddCar(new Car("Honda", "Civic", 2021, 22000));
                showroom.AddCar(new Car("BMW", "X5", 2023, 60000));

                // Act
                var expensiveCar = showroom.FindMostExpensiveCar();

                // Assert
                Assert.NotNull(expensiveCar);
                Assert.Equal("BMW", expensiveCar.Brand);
                Assert.Equal(60000, expensiveCar.Price);
            }

            [Fact]
            public void GetCarsByBrand_ShouldReturnFilteredCars()
            {
                // Arrange
                var showroom = new Showroom("Test Showroom");
                showroom.AddCar(new Car("Toyota", "Camry", 2022, 25000));
                showroom.AddCar(new Car("Toyota", "Corolla", 2021, 20000));
                showroom.AddCar(new Car("Honda", "Civic", 2021, 22000));

                // Act
                var toyotaCars = showroom.GetCarsByBrand("Toyota");

                // Assert
                Assert.Equal(2, toyotaCars.Count());
            }
        }
    
}
