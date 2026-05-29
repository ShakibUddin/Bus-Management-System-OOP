class BusHandler
{
    public static void CreateBus()
    {
        Console.WriteLine("========== CREATE BUS ==========");

        Console.Write("Coach  : ");
        string coach = Console.ReadLine() ?? "";

        Console.Write($"Classification({String.Join(", ", BusService.busSeatingCapacity.Keys)}) : ");
        string classification = Console.ReadLine() ?? "";

        BusService busService = new BusService();

        try
        {
            busService.CreateBus(coach, classification);
            Console.WriteLine();
            Console.WriteLine("Bus created successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("ERROR: " + ex.Message);
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public static void ShowAllBuses()
    {
        var buses = BusService.GetAllBuses();

        Console.WriteLine("========== ALL BUSES ==========");
        Console.WriteLine($"Total Buses: {buses.Count}");
        Console.WriteLine();

        Console.WriteLine(
            "Id".PadRight(5) +
            "Coach".PadRight(30) +
            "Classification".PadRight(30) +
            "Total Seating Capacity".PadRight(30) +
            "Created At"
        );

        Console.WriteLine(new string('-', 100));

        foreach (Bus bus in buses)
        {
            Console.WriteLine(
                bus.Id.ToString().PadRight(5) +
                bus.Coach.PadRight(30) +
                bus.Classification.ToString().PadRight(30) +
                bus.TotalSeatingCapacity.ToString().PadRight(30) +
                bus.CreatedAt.ToString("yyyy-MM-dd hh:mm tt")
            );
        }

        Console.WriteLine(new string('-', 100));

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}