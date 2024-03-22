using VehicleRentalManagementSystem;

//motorcycle class
public class Motorcycle : Vehicle
{
    public int EngineCapacity { get; private set; }
    public string FuelType { get; private set; }
    public bool HasFairing { get; private set; }

    public Motorcycle(string model, string manufacturer, int year, double rentalPrice,
        int enginecapacity, string fueltype, bool hasfairing) : base(model, manufacturer, year, rentalPrice)
    {
        EngineCapacity = enginecapacity;
        FuelType = fueltype;
        HasFairing = hasfairing;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Engine Type: {EngineCapacity} cc");
        Console.WriteLine($"Fuel Type: {FuelType}");
        Console.WriteLine($"Has Fairing: {(HasFairing ? "Yes" : "No")}");
    }
}