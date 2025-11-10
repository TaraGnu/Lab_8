using Lab_8;

class Program
{
    static void Main(string[] args)
    {
        var showroom = new Showroom("Мой Автосалон");

        showroom.AddCar(new Car("Toyota", "Camry", 2022, 25000));
        showroom.AddCar(new Car("Honda", "Civic", 2021, 22000));
        showroom.AddCar(new Car("BMW", "X5", 2023, 60000));
        showroom.AddCar(new Car("Audi", "A4", 2020, 35000));

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"=== {showroom.Name} ===");
            Console.WriteLine($"Автомобилей в наличии: {showroom.AvailableCarCount}/{showroom.CarCount}");
            Console.WriteLine($"Общая стоимость: {showroom.CalculateTotalValue():C}");
            Console.WriteLine();

            Console.WriteLine("1. Показать все автомобили");
            Console.WriteLine("2. Показать доступные автомобили");
            Console.WriteLine("3. Продать автомобиль");
            Console.WriteLine("4. Найти самый дешевый автомобиль");
            Console.WriteLine("5. Найти самый дорогой автомобиль");
            Console.WriteLine("6. Выход");
            Console.Write("Выберите действие: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowAllCars(showroom);
                    break;
                case "2":
                    ShowAvailableCars(showroom);
                    break;
                case "3":
                    SellCar(showroom);
                    break;
                case "4":
                    ShowCheapestCar(showroom);
                    break;
                case "5":
                    ShowMostExpensiveCar(showroom);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }

    static void ShowAllCars(Showroom showroom)
    {
        Console.WriteLine("\nВсе автомобили:");
        var cars = showroom.GetAvailableCars();
        int i = 1;
        foreach (var car in cars)
        {
            Console.WriteLine($"{i++}. {car}");
        }
    }

    static void ShowAvailableCars(Showroom showroom)
    {
        Console.WriteLine("\nДоступные автомобили:");
        var cars = showroom.GetAvailableCars();
        int i = 1;
        foreach (var car in cars)
        {
            Console.WriteLine($"{i++}. {car}");
        }
    }

    static void SellCar(Showroom showroom)
    {
        Console.Write("Введите марку: ");
        var brand = Console.ReadLine();
        Console.Write("Введите модель: ");
        var model = Console.ReadLine();

        var soldCar = showroom.SellCar(brand, model);
        if (soldCar != null)
        {
            Console.WriteLine($"Автомобиль {soldCar} продан!");
        }
        else
        {
            Console.WriteLine("Автомобиль не найден или уже продан!");
        }
    }

    static void ShowCheapestCar(Showroom showroom)
    {
        var car = showroom.FindCheapestCar();
        if (car != null)
        {
            Console.WriteLine($"Самый дешевый автомобиль: {car}");
        }
        else
        {
            Console.WriteLine("Нет доступных автомобилей!");
        }
    }

    static void ShowMostExpensiveCar(Showroom showroom)
    {
        var car = showroom.FindMostExpensiveCar();
        if (car != null)
        {
            Console.WriteLine($"Самый дорогой автомобиль: {car}");
        }
        else
        {
            Console.WriteLine("Нет доступных автомобилей!");
        }
    }
}