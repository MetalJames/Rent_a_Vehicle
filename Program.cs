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
    public int Capasity { get; set; }
    public string TruckType { get; set; }
    public bool FourWheelDrive { get; set; }

    public Truck(string model, string manufacturer, int year, double rentalPrice, 
        int capacity, string trucktype, bool fourwheel) : base(model, manufacturer, year, rentalPrice)
    {
        Capasity = capacity;
        TruckType = trucktype;
        FourWheelDrive = fourwheel;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Capasity: {Capasity}");
        Console.WriteLine($"Truck Type: {TruckType}");
        Console.WriteLine($"FourWheel Drive: {(FourWheelDrive ? "Yes" : "No")}");
    }
}

public class Motorcycle : Vehicle
{
    public int EngineCapacity { get; set; }
    public string FuelType { get; set; }
    public bool HasFairing { get; set; }

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

public class RentalAgency
{
    private Vehicle[] Fleet { get; set; }
    private double TotalRevenue;
    //add this to store rented vehicles
    private List<Vehicle> RentedVehicles;

    public RentalAgency (int capacity)
    {
        Fleet = new Vehicle[capacity];
        //creating new list to store a vehicle in it
        RentedVehicles = new List<Vehicle>();
        TotalRevenue = 0;
    }

    //add vehicle to fleet, either completely new vehicle or returned from customer
    public void AddVehicleToFleet(Vehicle vehicle)
    {
        for(int i = 0; i < Fleet.Length; i++)
        {
            if (Fleet[i] == null)
            {
                Fleet[i] = vehicle;
                break;
            }
        }
    }

    //removing vehicle from the fleet, renting to customer or removing it completely
    public void RemoveVehicleFromTheFleet(Vehicle vehicle)
    {
        for (int i = 0; i < Fleet.Length; i++)
        {
            if (Fleet[i] == vehicle)
            {
                Fleet[i] = null;
                break;
            }
        }
    }

    public void RentVehicle(Vehicle vehicle)
    {
        TotalRevenue += vehicle.RentalPrice;
        RentedVehicles.Add(vehicle);
        RemoveVehicleFromTheFleet(vehicle);
    }

    public void DisplayFleet()
    {
        Console.WriteLine("Fleet:");
        foreach (Vehicle vehicle in Fleet)
        {
            if(vehicle != null)
            {
                vehicle.DisplayDetails();
                Console.WriteLine();
            }
        }
    }

    public double GetTotalRevenue()
    {
        return TotalRevenue;
    }

    //displaying vehicles that we have rented(they not in fleet)
    // New method to display rented vehicles
    public void DisplayRentedVehicles()
    {
        Console.WriteLine("Rented Vehicles:");
        foreach (Vehicle vehicle in RentedVehicles)
        {
            vehicle.DisplayDetails();
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    //to keep security mesures we will retrive list of available vehicles for rent
    public List<Vehicle> GetAvailableVehicles()
    {
        List<Vehicle> availableVehicles = new List<Vehicle>();
        foreach (Vehicle vehicle in Fleet)
        {
            if (vehicle != null && !RentedVehicles.Contains(vehicle))
            {
                availableVehicles.Add(vehicle);
            }
        }
        return availableVehicles;
    }
    //to make main method look smaller we will be getting choice in here
    public static int GetValidChoice(int count)
    {
        while (true)
        {
            Console.Write($"Enter your choice (1-{count}): ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > count)
            {
                Console.WriteLine("Invalid choice. Please select a valid number.");
            }
            else
            {
                return choice;
            }
        }
    }
}

class Rent_a_Car
{
    static void Main(string[] args)
    {
        //creating our rental agency
        RentalAgency rentAvehicle= new RentalAgency(100);

        Car escape = new Car("Escape", "Ford", 2010, 60, 5, "Gasoline", "Automatic", false);
        rentAvehicle.AddVehicleToFleet(escape);
        Car camry = new Car("Camry", "Toyota", 2022, 50, 5, "V6", "Automatic", false);
        rentAvehicle.AddVehicleToFleet(camry);

        Truck econicSD = new Truck("EconicSD", "Freightliner", 2018, 60, 2, "Heavy Duty", false);
        rentAvehicle.AddVehicleToFleet(econicSD);
        Truck f150 = new Truck("F-150", "Ford", 2021, 80, 1000, "Pickup", true);
        rentAvehicle.AddVehicleToFleet(f150);

        Motorcycle ducati916 = new Motorcycle("1998 Ducati 916", "Ducati", 1998, 200, 916, "Gasoline", true);
        rentAvehicle.AddVehicleToFleet(ducati916);
        Motorcycle kawasakiNinja = new Motorcycle("Ninja", "Kawasaki", 2023, 40, 600, "Gasoline", true);
        rentAvehicle.AddVehicleToFleet (kawasakiNinja);

        /*        rentAvehicle.DisplayFleet();

                Console.WriteLine($"Total Revenue: {rentAvehicle.GetTotalRevenue()}");*/

        Console.WriteLine("Rent a vehicle managament system");
        Console.WriteLine();

        bool RentIsOpen = true;

        while(RentIsOpen)
        {
            Console.WriteLine("What you would like to do:");
            Console.WriteLine();
            Console.WriteLine("1. See the Fleet stock.");
            Console.WriteLine("2. Rent a vehicle.");
            Console.WriteLine("3. Return vehicle to Fleet");
            Console.WriteLine("4. Add new vehicel");
            Console.WriteLine("5. See currently rented vehicles");
            Console.WriteLine("6. Close a store.");
            Console.WriteLine();

            // Get customer choice
            Console.Write("Enter your choice (1-6): ");

            // This will prevent the program from crashing if the user enters anything else besides 1-5 (character or any special character)
            bool validActionInput = int.TryParse(Console.ReadLine(), out int mainMenuChoice);

            if (!validActionInput || mainMenuChoice < 1 || mainMenuChoice > 5)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                continue;
            }

            switch (mainMenuChoice)
            {
                case 1:
                    rentAvehicle.DisplayFleet();
                    Console.WriteLine($"Total Revenue: {rentAvehicle.GetTotalRevenue()} Cad");
                    Console.WriteLine();
                    break;
                case 2:
                    RentVehicle(rentAvehicle);
                    break;
                case 3: Console.WriteLine("Test 3");
                    break;
                case 4: Console.WriteLine("Test 4");
                    break;
                case 5:
                    rentAvehicle.DisplayRentedVehicles();
                    break;
                case 6:
                    RentIsOpen = false;
                    break;
            }
        }
    }

    private static void RentVehicle(RentalAgency rentalAgency)
    {
        Console.WriteLine();
        Console.WriteLine("Choose a vehicle to rent:");

        var availableVehicles = rentalAgency.GetAvailableVehicles();

        if (availableVehicles.Count == 0)
        {
            Console.WriteLine("Currently, there are no vehicles available for rent.");
            return;
        }

        for (int i = 0; i < availableVehicles.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableVehicles[i].Manufacturer} {availableVehicles[i].Model} ({availableVehicles[i].Year})");
        }

        int choice = RentalAgency.GetValidChoice(availableVehicles.Count);

        // Rent the selected vehicle
        var vehicleToRent = availableVehicles[choice - 1];
        rentalAgency.RentVehicle(vehicleToRent);
        Console.WriteLine($"You have rented the {vehicleToRent.Manufacturer} {vehicleToRent.Model}.");
        Console.WriteLine();
    }
}