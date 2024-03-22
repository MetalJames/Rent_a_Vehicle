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

        Truck econicSD = new Truck("EconicSD", "Freightliner", 2018, 60, 8000, "Heavy Duty", false);
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
                    Console.WriteLine($"Total vehicles available: {rentAvehicle.GetAvailableVehicles().Count}");
                    Console.WriteLine("--------------------------------------------------");
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

        var availableVehicles = rentalAgency.GetAvailableVehicles();

        if (availableVehicles.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Currently, there are no vehicles available for rent.");
            Console.WriteLine();
            return;
        }

        Console.WriteLine("Choose a vehicle to rent:");
        Console.WriteLine();

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
        Console.WriteLine();
        Console.WriteLine($"You have rented the {vehicleToRent.Manufacturer} {vehicleToRent.Model}.");
    }

    //method to provide choice of returning vehicles
    private static void ReturnVehicle(RentalAgency rentalAgency)
    {
        var rentedVehicles = rentalAgency.GetRentedVehicles();

        if (rentedVehicles.Count == 0)
        {
            Console.WriteLine();
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
        Console.WriteLine();
        Console.WriteLine($"You have returned the {vehicleToReturn.Manufacturer} {vehicleToReturn.Model}.");
    }
}