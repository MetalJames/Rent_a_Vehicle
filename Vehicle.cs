namespace VehicleRentalManagementSystem;

//vehicle abstract class
public abstract class Vehicle
{
    public string Model { get; private set; }
    public string Manufacturer { get; private set; }
    public int Year { get; private set; }

    //private field for RentalPrice
    private double rentalPrice;

    //public property for RentalPrice
    public double RentalPrice
    {
        get { return rentalPrice; }
        set { rentalPrice = value; }
    }

    public Vehicle(string model, string manufacturer, int year, double rentalPrice)
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
        Console.WriteLine($"Rental Price: {RentalPrice} Cad");
    }
}