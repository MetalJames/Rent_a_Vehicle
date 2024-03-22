using VehicleRentalManagementSystem;

public class RentalAgency
{
    private Vehicle[] Fleet { get; set; }
    private double TotalRevenue;
    //add this to store rented vehicles
    private Vehicle[] RentedVehicles { get; set; }

    public RentalAgency(int capacity)
    {
        Fleet = new Vehicle[capacity];
        //creating new array to store a vehicle in it
        RentedVehicles = new Vehicle[capacity];
        TotalRevenue = 0;
    }

    //add vehicle to fleet
    public void AddVehicleToFleet(Vehicle vehicle)
    {
        for (int i = 0; i < Fleet.Length; i++)
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
            if (vehicle != null)
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
            Console.WriteLine();
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
            Console.WriteLine("Feel free to reach out about availability.");
        }
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
        Console.Write("Enter the model: ");
        string model = Console.ReadLine();

        Console.Write("Enter the manufacturer: ");
        string manufacturer = Console.ReadLine();

        Console.Write("Enter the year: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Enter the rental price: ");
        double rentalPrice = double.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Enter the number of seats: ");
                int seats = int.Parse(Console.ReadLine());

                Console.Write("Enter the engine type: ");
                string engineType = Console.ReadLine();

                Console.Write("Enter the transmission type: ");
                string transmission = Console.ReadLine();

                Console.Write("Is it convertible? (yes/no): ");
                string convertibleInput = Console.ReadLine().ToLower();
                bool convertible = convertibleInput == "yes" || convertibleInput == "y";


                Car car = new Car(model, manufacturer, year, rentalPrice, seats, engineType, transmission, convertible);
                AddVehicleToFleet(car);
                break;
            case 2:
                Console.Write("Enter the truck capacity(kg): ");
                double capacity = double.Parse(Console.ReadLine());

                Console.Write("Enter the truck type: ");
                string truckType = Console.ReadLine();

                Console.Write("Is it four-wheel drive? (yes/no): ");
                string fourWheelDriveInput = Console.ReadLine().ToLower();
                bool fourWheelDrive = fourWheelDriveInput == "yes" || fourWheelDriveInput == "y";


                Truck truck = new Truck(model, manufacturer, year, rentalPrice, capacity, truckType, fourWheelDrive);
                AddVehicleToFleet(truck);
                break;
            case 3:
                Console.Write("Enter the engine capacity: ");
                double engineCapacity = double.Parse(Console.ReadLine());

                Console.Write("Enter the fuel type: ");
                string fuelType = Console.ReadLine();

                Console.Write("Does it have a fairing? (yes/no): ");
                string fairingInput = Console.ReadLine().ToLower();
                bool hasFairing = fairingInput == "yes" || fairingInput == "y";

                Motorcycle motorcycle = new Motorcycle(model, manufacturer, year, rentalPrice, engineCapacity, fuelType, hasFairing);
                AddVehicleToFleet(motorcycle);
                break;
        }
        Console.WriteLine();
        Console.WriteLine("Vehicle added successfully!");
    }
}