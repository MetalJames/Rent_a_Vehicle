using VehicleRentalManagementSystem;

//truck class
public class Truck : Vehicle
{
    public double Capasity { get; private set; }
    public string TruckType { get; private set; }
    public bool FourWheelDrive { get; private set; }

    public Truck(string model, string manufacturer, int year, double rentalPrice,
        double capacity, string trucktype, bool fourwheel) : base(model, manufacturer, year, rentalPrice)
    {
        Capasity = capacity;
        TruckType = trucktype;
        FourWheelDrive = fourwheel;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Capasity: {Capasity} kg");
        Console.WriteLine($"Truck Type: {TruckType}");
        Console.WriteLine($"FourWheel Drive: {(FourWheelDrive ? "Yes" : "No")}");
    }
}