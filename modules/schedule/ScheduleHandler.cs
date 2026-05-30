class ScheduleHandler
{
    public static void CreateSchedule(ScheduleService scheduleService, BusService busService)
    {
        Console.WriteLine("========== CREATE SCHEDULE ==========");

        Console.Write("Bus Id  : ");
        string busId = Console.ReadLine() ?? "";

        Console.WriteLine("Departure City : ");
        Console.Write($"Cities({String.Join(", ", ScheduleManager.availableCities)}) : ");
        string departureCity = Console.ReadLine() ?? "";

        Console.WriteLine("Arrival City : ");
        Console.Write($"Cities({String.Join(", ", ScheduleManager.availableCities)}) : ");
        string arrivalCity = Console.ReadLine() ?? "";

        Console.Write("Departure Date(YYYY-MM-DD) : ");
        string departureDate = Console.ReadLine() ?? "";


        Console.WriteLine("Departure Time : ");
        Console.Write($"Slots({String.Join(", ", ScheduleManager.availableTimeSlots)}) : ");
        string departureTime = Console.ReadLine() ?? "";

        Console.Write("Ticket Price(BDT) : ");
        string ticketPrice = Console.ReadLine() ?? "";

        int busIdNumber = 0;
        decimal ticketPriceDecimal = decimal.Parse(ticketPrice);
        try
        {
            busIdNumber = int.Parse(busId);
        }
        catch
        {
            Console.WriteLine("Invalid Bus Id!");
        }
        Console.WriteLine($"busIdNumber: {busIdNumber}");

        Bus bus = busService.GetBusById(busIdNumber);


        try
        {
            scheduleService.CreateSchedule(busIdNumber, bus.Classification, departureCity, arrivalCity, departureDate, departureTime, ticketPriceDecimal);
            Console.WriteLine();
            Console.WriteLine("Schedule created successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("ERROR: " + ex.Message);
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    public static void ShowAllSchedules()
    {
        var schedules = ScheduleService.GetAllSchedulees();

        Console.WriteLine("========== ALL SCHEDULES ==========\n");
        Console.WriteLine($"Total Schedules: {schedules.Count}\n");

        Console.WriteLine(
                            "Id".PadRight(5) +
                            "BusId".PadRight(10) +
                            "Route".PadRight(30) +
                            "Departure".PadRight(20) +
                            "Ticket Price".PadRight(20) +
                            "Created At"
                        );
        foreach (Schedule schedule in schedules)
        {
            Console.WriteLine(
               schedule.Id.ToString().PadRight(5) +
               schedule.BusId.ToString().PadRight(10) +
               $"{schedule.DepartureCity} -> {schedule.ArrivalCity}".PadRight(30) +
               $"{schedule.DepartureDate} | {schedule.DepartureTime}".ToString().PadRight(20) +
               schedule.TicketPrice.ToString().PadRight(20) +
               schedule.CreatedAt.ToString("yyyy-MM-dd hh:mm tt")
           );
        }

        Console.WriteLine(new string('=', 90));
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    public static void ShowScheduleDetails(ScheduleService scheduleService, BusService busService)
    {
        Console.Write("Schedule ID  : ");
        string scheduleId = Console.ReadLine() ?? "";
        int scheduleIdNumber = 0;
        try
        {
            scheduleIdNumber = int.Parse(scheduleId);
        }
        catch
        {
            Console.WriteLine("Invalid Schedule Id!");
        }
        Schedule schedule = scheduleService.GetScheduleById(scheduleIdNumber);

        Console.WriteLine("========== SCHEDULE DETAILS ==========\n");

        Bus bus = busService.GetBusById(schedule.BusId);

        int seatsPerRow = bus.Classification == BusClassifications.Business ? 3 : 4;

        int seatingCapacity = BusService.busSeatingCapacity[bus.Classification];
        int rows = seatingCapacity / seatsPerRow;

        Console.WriteLine(new string('=', 70));
        Console.WriteLine($"Schedule Id   : {schedule.Id}");
        Console.WriteLine($"Bus Id        : {schedule.BusId}");
        Console.WriteLine($"Class         : {bus.Classification}");
        Console.WriteLine($"Route         : {schedule.DepartureCity} -> {schedule.ArrivalCity}");
        Console.WriteLine($"Departure     : {schedule.DepartureDate} | {schedule.DepartureTime}");
        Console.WriteLine($"Price         : {schedule.TicketPrice} BDT");

        Console.WriteLine(new string('-', 70));

        // LEGEND
        Console.WriteLine("Seat Layout ([ ] Available        [X] Booked      [✓] Confirmed):\n");
        Console.WriteLine();

        char row = 'A';

        for (int i = 0; i < rows; i++)
        {
            if (seatsPerRow == 3)
            {
                // BUSINESS => 1 + aisle + 2

                string seat1 = $"{row}1";
                string seat2 = $"{row}2";
                string seat3 = $"{row}3";

                string symbol1 =
                    schedule.SeatPlan[seat1] == BusSeatStatus.Confirmed
                    ? "✓" : schedule.SeatPlan[seat1] == BusSeatStatus.Booked ? "X" : " ";

                string symbol2 =
                    schedule.SeatPlan[seat2] == BusSeatStatus.Confirmed
                    ? "✓" : schedule.SeatPlan[seat2] == BusSeatStatus.Booked ? "X" : " ";

                string symbol3 =
                    schedule.SeatPlan[seat3] == BusSeatStatus.Confirmed
                    ? "✓" : schedule.SeatPlan[seat3] == BusSeatStatus.Booked ? "X" : " ";

                Console.WriteLine(
                    $"[{seat1}:{symbol1}]        [{seat2}:{symbol2}] [{seat3}:{symbol3}]"
                );
            }
            else
            {
                // ECONOMY => 2 + aisle + 2

                string seat1 = $"{row}1";
                string seat2 = $"{row}2";
                string seat3 = $"{row}3";
                string seat4 = $"{row}4";

                string symbol1 =
                    schedule.SeatPlan[seat1] == BusSeatStatus.Confirmed
                    ? "✓" : schedule.SeatPlan[seat1] == BusSeatStatus.Booked ? "X" : " ";

                string symbol2 =
                    schedule.SeatPlan[seat2] == BusSeatStatus.Confirmed
                    ? "✓" : schedule.SeatPlan[seat2] == BusSeatStatus.Booked ? "X" : " ";

                string symbol3 =
                    schedule.SeatPlan[seat3] == BusSeatStatus.Confirmed
                    ? "✓" : schedule.SeatPlan[seat3] == BusSeatStatus.Booked ? "X" : " ";

                string symbol4 =
                    schedule.SeatPlan[seat4] == BusSeatStatus.Confirmed
                    ? "✓" : schedule.SeatPlan[seat4] == BusSeatStatus.Booked ? "X" : " ";

                Console.WriteLine(
                    $"[{seat1}:{symbol1}] [{seat2}:{symbol2}]        [{seat3}:{symbol3}] [{seat4}:{symbol4}]"
                );
            }

            row++;
        }

        Console.WriteLine("\n");

        Console.WriteLine(new string('=', 70));
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}