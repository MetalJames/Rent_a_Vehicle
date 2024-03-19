public abstract class Vehicle
{
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public int Year { get; set; }
    public double RentalPrice { get; set; }

    public Vehicle (string model, string manufacturer, int year, double rentalPrice)
    {
        Model = model;
        Manufacturer = manufacturer;
        Year = year;
        RentalPrice = rentalPrice;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Manufacturer: {Manufacturer}");
        Console.WriteLine($"Year: {Year}");
        Console.WriteLine($"Rental Price: {RentalPrice}");
    }
}

public class Car : Vehicle
{
    public int Seats { get; set; }
    public string EngineType { get; set; }
    public string Transmission {  get; set; }
    public bool Convertible { get; set; }

    public Car (string model, string manufacturer, int year, double rentalPrice, int seats, string engineType, string transmission, bool convertible) : base(model, manufacturer, year, rentalPrice)
    {
        Seats = seats;
        EngineType = engineType;
        Transmission = transmission;
        Convertible = convertible;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Seats: {Seats}");
        Console.WriteLine($"EngineType: {EngineType}");
        Console.WriteLine($"Transmission: {Transmission}");
        Console.WriteLine($"Convertible: {(Convertible ? "Yes" : "No")}");
    }
}

public class Truck : Vehicle
{
    public int Seats { get; set; }
    public string EngineType { get; set; }
    public string Transmission { get; set; }
    public bool Convertible { get; set; }
    public int Capasity { get; set; }
    public string TruckType { get; set; }
    public bool FourWheelDrive { get; set; }

    public Truck(string model, string manufacturer, int year, double rentalPrice, int seats, string engineType, string transmission, bool convertible, 
        int capacity, string trucktype, bool fourwheel) : base(model, manufacturer, year, rentalPrice)
    {
        Seats = seats;
        EngineType = engineType;
        Transmission = transmission;
        Convertible = convertible;
        Capasity = capacity;
        TruckType = trucktype;
        FourWheelDrive = fourwheel;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Seats: {Seats}");
        Console.WriteLine($"EngineType: {EngineType}");
        Console.WriteLine($"Transmission: {Transmission}");
        Console.WriteLine($"Convertible: {(Convertible ? "Yes" : "No")}");
        Console.WriteLine($"Capasity: {Capasity}");
        Console.WriteLine($"TruckType: {TruckType}");
        Console.WriteLine($"FourWheelDrive: {(FourWheelDrive ? "Yes" : "No")}");
    }
}

class Rent_a_Car
{
    static void Main(string[] args)
    {
        Car car = new Car("Escape", "Ford", 2010, 60, 5, "Gasoline", "Automatic", false);
        car.DisplayDetails();
        Console.WriteLine();
        Truck truck = new Truck("Escape", "Ford", 2010, 60, 5, "Gasoline", "Automatic", false, 8, "Freightliner", true);
        truck.DisplayDetails();
        Console.WriteLine();
    }
}