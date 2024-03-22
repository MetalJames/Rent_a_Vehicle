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
                //preventing warning, this will not be null
                Fleet[i] = null!;
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
                //preventing warning, this will not be null
                RentedVehicles[i] = null!;
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
        //from here preventing errors if user enter empty line
        string model = Console.ReadLine()!;
        //check if the input is empty, maybe customer forgot or accidentally press enter
        while (string.IsNullOrWhiteSpace(model))
        {
            Console.WriteLine("Model cannot be empty. Please enter a valid model:");
            model = Console.ReadLine()!;
        }

        Console.Write("Enter the manufacturer: ");
        //from here preventing errors if user enter empty line
        string manufacturer = Console.ReadLine()!;
        //check if the input is empty, maybe customer forgot or accidentally press enter
        while (string.IsNullOrWhiteSpace(manufacturer))
        {
            Console.WriteLine("Manufacturer cannot be empty. Please enter a valid manufacturer:");
            manufacturer = Console.ReadLine()!;
        }

        Console.Write("Enter the year: ");
        int year;
        //check if the input is empty, maybe customer forgot or accidentally press enter
        while (!int.TryParse(Console.ReadLine(), out year) || year < 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid year:");
        }

        Console.Write("Enter the rental price: ");
        double rentalPrice;
        //check if the input is empty, maybe customer forgot or accidentally press enter
        while (!double.TryParse(Console.ReadLine(), out rentalPrice) || rentalPrice < 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid rental price:");
        }

        switch (choice)
        {
            case 1:
                Console.Write("Enter the number of seats: ");
                int seats;
                //check if the input is empty, maybe customer forgot or accidentally press enter
                while (!int.TryParse(Console.ReadLine(), out seats) || seats <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number of seats:");
                }

                Console.Write("Enter the engine type: ");
                string engineType = Console.ReadLine()!;
                //check if the input is empty, maybe customer forgot or accidentally press enter
                while (string.IsNullOrWhiteSpace(engineType))
                {
                    Console.WriteLine("Engine type cannot be empty. Please enter a valid engine type:");
                    engineType = Console.ReadLine()!;
                }

                Console.Write("Enter the transmission type: ");
                string transmission = Console.ReadLine()!;
                //check if the input is empty, maybe customer forgot or accidentally press enter
                while (string.IsNullOrWhiteSpace(transmission))
                {
                    Console.WriteLine("Transmission type cannot be empty. Please enter a valid transmission type:");
                    transmission = Console.ReadLine()!;
                }

                Console.Write("Is it convertible? (yes/no): ");
                string convertibleInput = Console.ReadLine()!.ToLower();
                bool convertible;
                //check if the input is empty, maybe customer forgot or accidentally press enter
                while (convertibleInput != "yes" && convertibleInput != "no" && convertibleInput != "y" && convertibleInput != "n")
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no':");
                    convertibleInput = Console.ReadLine()!.ToLower();
                }
                convertible = convertibleInput == "yes" || convertibleInput == "y";

                Car car = new Car(model, manufacturer, year, rentalPrice, seats, engineType, transmission, convertible);
                AddVehicleToFleet(car);
                break;
            case 2:
                Console.Write("Enter the truck capacity(kg): ");
                double capacity;
                //check if the input is empty, maybe customer forgot or accidentally press enter
                while (!double.TryParse(Console.ReadLine(), out capacity) || capacity <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid truck capacity:");
                }

                Console.Write("Enter the truck type: ");
                //check if the input is empty, maybe customer forgot or accidentally press enter
                string truckType = Console.ReadLine()!;
                while (string.IsNullOrWhiteSpace(truckType))
                {
                    Console.WriteLine("Truck type cannot be empty. Please enter a valid truck type:");
                    truckType = Console.ReadLine()!;
                }

                Console.Write("Is it four-wheel drive? (yes/no): ");
                string fourWheelDriveInput = Console.ReadLine()!.ToLower();
                bool fourWheelDrive;
                //check if the input is empty, maybe customer forgot or accidentally press enter
                while (fourWheelDriveInput != "yes" && fourWheelDriveInput != "no" && fourWheelDriveInput != "y" && fourWheelDriveInput != "n")
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no':");
                    fourWheelDriveInput = Console.ReadLine()!.ToLower();
                }
                fourWheelDrive = fourWheelDriveInput == "yes" || fourWheelDriveInput == "y";

                Truck truck = new Truck(model, manufacturer, year, rentalPrice, capacity, truckType, fourWheelDrive);
                AddVehicleToFleet(truck);
                break;
            case 3:
                Console.Write("Enter the engine capacity: ");
                double engineCapacity;
                //check if the input is empty, maybe customer forgot or accidentally press enter
                while (!double.TryParse(Console.ReadLine(), out engineCapacity) || engineCapacity <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid engine capacity:");
                }

                Console.Write("Enter the fuel type: ");
                string fuelType = Console.ReadLine()!;
                //check if the input is empty, maybe customer forgot or accidentally press enter
                while (string.IsNullOrWhiteSpace(fuelType))
                {
                    Console.WriteLine("Fuel type cannot be empty. Please enter a valid fuel type:");
                    fuelType = Console.ReadLine()!;
                }

                Console.Write("Does it have a fairing? (yes/no): ");
                string fairingInput = Console.ReadLine()!.ToLower();
                bool hasFairing;
                //check if the input is empty, maybe customer forgot or accidentally press enter
                while (fairingInput != "yes" && fairingInput != "no" && fairingInput != "y" && fairingInput != "n")
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no':");
                    fairingInput = Console.ReadLine()!.ToLower();
                }
                hasFairing = fairingInput == "yes" || fairingInput == "y";

                Motorcycle motorcycle = new Motorcycle(model, manufacturer, year, rentalPrice, engineCapacity, fuelType, hasFairing);
                AddVehicleToFleet(motorcycle);
                break;
        }
        Console.WriteLine();
        Console.WriteLine("Vehicle added successfully!");
    }
}