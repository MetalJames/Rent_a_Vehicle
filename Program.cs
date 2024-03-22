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

//car class
public class Car : Vehicle
{
    public int Seats { get; private set; }
    public string EngineType { get; private set; }
    public string Transmission {  get; private set; }
    public bool Convertible { get; private set; }

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

//truck class
public class Truck : Vehicle
{
    public int Capasity { get; private set; }
    public string TruckType { get; private set; }
    public bool FourWheelDrive { get; private set; }

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

//rental agency class
public class RentalAgency
{
    private Vehicle[] Fleet { get; set; }
    private double TotalRevenue;
    //add this to store rented vehicles
    private Vehicle[] RentedVehicles { get; set; }

    public RentalAgency (int capacity)
    {
        Fleet = new Vehicle[capacity];
        //creating new array to store a vehicle in it
        RentedVehicles = new Vehicle[capacity];
        TotalRevenue = 0;
    }

    //add vehicle to fleet
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

    //add vehicle to rented
    public void AddVehicleToRented(Vehicle vehicle)
    {
        for (int i = 0; i < RentedVehicles.Length; i++)
        {
            if (RentedVehicles[i] == null)
            {
                RentedVehicles[i] = vehicle;
                break;
            }
        }
    }

    //removing vehicle from the fleet
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

    //removing vehicle from the rented
    public void RemoveVehicleFromRented(Vehicle vehicle)
    {
        for (int i = 0; i < RentedVehicles.Length; i++)
        {
            if (RentedVehicles[i] == vehicle)
            {
                RentedVehicles[i] = null;
                break;
            }
        }
    }

    //renting vehicle
    public void RentVehicle(Vehicle vehicle)
    {
        TotalRevenue += vehicle.RentalPrice;
        AddVehicleToRented(vehicle);
        RemoveVehicleFromTheFleet(vehicle);
    }

    //display fleet
    public void DisplayFleet()
    {
        Console.WriteLine("Fleet:");
        Console.WriteLine();
        foreach (Vehicle vehicle in Fleet)
        {
            if(vehicle != null)
            {
                vehicle.DisplayDetails();
                Console.WriteLine();
            }
        }
    }

    //get total revenue
    public double GetTotalRevenue()
    {
        return TotalRevenue;
    }

    //displaying vehicles that we have rented(they not in fleet)
    //new method to display rented vehicles
    public void DisplayRentedVehicles()
    {
        List<Vehicle> rentedVehicles = GetRentedVehicles();

        if (rentedVehicles.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("There are no rented vehicles.");
        }
        else
        {
            Console.WriteLine("Rented Vehicles:");
            Console.WriteLine();
            foreach (Vehicle vehicle in rentedVehicles)
            {
                if (vehicle != null)
                {
                    vehicle.DisplayDetails();
                    Console.WriteLine();
                }
            }
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

    //getting list of rented vehicles
    public List<Vehicle> GetRentedVehicles()
    {
        List<Vehicle> rentedVehicles = new List<Vehicle>();
        foreach (Vehicle vehicle in RentedVehicles)
        {
            if (vehicle != null && !Fleet.Contains(vehicle))
            {
                rentedVehicles.Add(vehicle);
            }
        }
        return rentedVehicles;
    }

    //to make main method look smaller we will be getting choice in here
    public static int GetValidChoice(int count)
    {
        while (true)
        {
            Console.Write($"Enter your choice (0-{count}): ");
            Console.WriteLine();
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > count)
            {
                Console.WriteLine("Invalid choice. Please select a valid number.");
            }
            else
            {
                return choice;
            }
        }
    }

    //add completely new vehicle to our fleet
    public void AddNewVehicle()
    {
        Console.WriteLine("Select the type of vehicle you whould like to add:");
        Console.WriteLine();
        Console.WriteLine("1. Car");
        Console.WriteLine("2. Truck");
        Console.WriteLine("3. Motorcycle");
        Console.WriteLine("0. Back to Main Menu");
        Console.WriteLine();

        int choice = GetValidChoice(3);

        if (choice == 0)
            return;

        string vehicleType = "";

        switch (choice)
        {
            case 1:
                vehicleType = "Car";
                break;
            case 2:
                vehicleType = "Truck";
                break;
            case 3:
                vehicleType = "Motorcycle";
                break;
        }

        Console.WriteLine();
        Console.WriteLine($"You are adding {vehicleType}");

        Console.WriteLine();
        Console.WriteLine("Enter the model: ");
        string model = Console.ReadLine();

        Console.WriteLine("Enter the manufacturer: ");
        string manufacturer = Console.ReadLine();

        Console.WriteLine("Enter the year: ");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the rental price: ");
        double rentalPrice = double.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter the number of seats: ");
                int seats = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the engine type: ");
                string engineType = Console.ReadLine();

                Console.WriteLine("Enter the transmission type: ");
                string transmission = Console.ReadLine();

                Console.WriteLine("Is it convertible? (true/false): ");
                bool convertible = bool.Parse(Console.ReadLine());

                Car car = new Car(model, manufacturer, year, rentalPrice, seats, engineType, transmission, convertible);
                AddVehicleToFleet(car);
                break;
            case 2:
                Console.WriteLine("Enter the capacity: ");
                int capacity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the truck type: ");
                string truckType = Console.ReadLine();

                Console.WriteLine("Is it four-wheel drive? (true/false): ");
                bool fourWheelDrive = bool.Parse(Console.ReadLine());

                Truck truck = new Truck(model, manufacturer, year, rentalPrice, capacity, truckType, fourWheelDrive);
                AddVehicleToFleet(truck);
                break;
            case 3:
                Console.WriteLine("Enter the engine capacity: ");
                int engineCapacity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the fuel type: ");
                string fuelType = Console.ReadLine();

                Console.WriteLine("Does it have a fairing? (yes/no): ");
                string fairingInput = Console.ReadLine().ToLower();
                bool hasFairing = fairingInput == "yes" || fairingInput == "y";

                Motorcycle motorcycle = new Motorcycle(model, manufacturer, year, rentalPrice, engineCapacity, fuelType, hasFairing);
                AddVehicleToFleet(motorcycle);
                break;
        }
        Console.WriteLine("Vehicle added successfully!");
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

            //get customer choice
            Console.Write("Enter your choice (1-6): ");

            //this will prevent the program from crashing if the user enters anything else besides 1-6 (character or any special character)
            bool validActionInput = int.TryParse(Console.ReadLine(), out int mainMenuChoice);

            if (!validActionInput || mainMenuChoice < 1 || mainMenuChoice > 6)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                continue;
            }

            switch (mainMenuChoice)
            {
                case 1:
                    Console.WriteLine("--------------------------------------------------");
                    rentAvehicle.DisplayFleet();
                    Console.WriteLine($"Total Revenue: {rentAvehicle.GetTotalRevenue()} Cad");
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("--------------------------------------------------");
                    RentVehicle(rentAvehicle);
                    Console.WriteLine("--------------------------------------------------");
                    break;
                case 3:
                    Console.WriteLine("--------------------------------------------------");
                    ReturnVehicle(rentAvehicle);
                    Console.WriteLine("--------------------------------------------------");
                    break;
                case 4:
                    Console.WriteLine("--------------------------------------------------");
                    rentAvehicle.AddNewVehicle();
                    Console.WriteLine("--------------------------------------------------");
                    break;
                case 5:
                    Console.WriteLine("--------------------------------------------------");
                    rentAvehicle.DisplayRentedVehicles();
                    Console.WriteLine("--------------------------------------------------");
                    break;
                case 6:
                    RentIsOpen = false;
                    break;
            }
        }
    }

    //method to provide choice of renting vehicles
    private static void RentVehicle(RentalAgency rentalAgency)
    {
        Console.WriteLine();
        Console.WriteLine("Choose a vehicle to rent:");
        Console.WriteLine();

        var availableVehicles = rentalAgency.GetAvailableVehicles();

        if (availableVehicles.Count == 0)
        {
            Console.WriteLine("Currently, there are no vehicles available for rent.");
            Console.WriteLine();
            return;
        }

        for (int i = 0; i < availableVehicles.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableVehicles[i].Manufacturer} {availableVehicles[i].Model} ({availableVehicles[i].Year})");
        }

        Console.WriteLine("0. Back to Main Menu");
        Console.WriteLine();

        int choice = RentalAgency.GetValidChoice(availableVehicles.Count);

        if (choice == 0)
            return;

        //rent the selected vehicle
        var vehicleToRent = availableVehicles[choice - 1];
        rentalAgency.RentVehicle(vehicleToRent);
        Console.WriteLine($"You have rented the {vehicleToRent.Manufacturer} {vehicleToRent.Model}.");
        Console.WriteLine();
    }

    //method to provide choice of returning vehicles
    private static void ReturnVehicle(RentalAgency rentalAgency)
    {
        Console.WriteLine();

        var rentedVehicles = rentalAgency.GetRentedVehicles();

        if (rentedVehicles.Count == 0)
        {
            Console.WriteLine("You have not rented any vehicles.");
            Console.WriteLine();
            return;
        }

        Console.WriteLine("Choose a vehicle to return:");
        Console.WriteLine();

        for (int i = 0; i < rentedVehicles.Count; i++)
        {
            if (rentedVehicles[i] != null)
            {
                Console.WriteLine($"{i + 1}. {rentedVehicles[i].Manufacturer} {rentedVehicles[i].Model} ({rentedVehicles[i].Year})");
            }
        }

        Console.WriteLine("0. Back to Main Menu");
        Console.WriteLine();

        int choice = RentalAgency.GetValidChoice(rentedVehicles.Count);

        if (choice == 0)
            return;

        var vehicleToReturn = rentedVehicles[choice - 1];
        rentalAgency.RemoveVehicleFromRented(vehicleToReturn);
        rentalAgency.AddVehicleToFleet(vehicleToReturn);
        Console.WriteLine($"You have returned the {vehicleToReturn.Manufacturer} {vehicleToReturn.Model}.");
        Console.WriteLine();
    }
}