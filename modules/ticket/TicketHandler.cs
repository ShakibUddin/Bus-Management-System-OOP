class TicketHandler
{
    public static void BookTicket(BookingService bookingService, ScheduleService scheduleService)
    {
        Console.WriteLine("========== BOOK TICKET ==========\n");

        Console.Write("Schedule Id : ");
        string scheduleId = Console.ReadLine() ?? "";

        Console.Write("User Id     : ");
        string userId = Console.ReadLine() ?? "";

        Console.Write("Seat (e.g A1): ");
        string seat = (Console.ReadLine() ?? "").ToUpper();

        try
        {
            int scheduleIdNumber = int.Parse(scheduleId);
            int userIdNumber = int.Parse(userId);

            Dictionary<string, BusSeatStatus> seatPlan = scheduleService.GetScheduleById(scheduleIdNumber).SeatPlan;

            decimal amountDue = scheduleService.GetScheduleById(scheduleIdNumber).TicketPrice;

            bookingService.BookTicket(
                scheduleIdNumber,
                userIdNumber,
                seat,
                seatPlan,
                amountDue
            );
            Console.WriteLine();
            Console.WriteLine("Ticket booked successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("ERROR: " + ex.Message);
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    public static void ShowUserTickets(TicketService ticketService, ScheduleService scheduleService)
    {
        Console.WriteLine("========== USER TICKETS ==========\n");

        Console.Write("User Id : ");
        string userId = Console.ReadLine() ?? "";

        try
        {
            int userIdNumber = int.Parse(userId);

            List<Ticket> tickets = ticketService.GetTicketsByUserId(userIdNumber);

            if (tickets.Count == 0)
            {
                Console.WriteLine("\nNo Tickets Found!");
            }
            else
            {
                Console.WriteLine();

                Console.WriteLine(
                    "TicketId".PadRight(12) +
                    "ScheduleId".PadRight(15) +
                    "Seat".PadRight(10) +
                    "Route".PadRight(30) +
                    "Departure"
                );

                Console.WriteLine(new string('-', 100));

                foreach (Ticket ticket in tickets)
                {
                    Schedule schedule =
                        scheduleService.GetScheduleById(ticket.ScheduleId);

                    Console.WriteLine(
                        ticket.Id.ToString().PadRight(12) +
                        ticket.ScheduleId.ToString().PadRight(15) +
                        ticket.Seat.PadRight(10) +
                        $"{schedule.DepartureCity} -> {schedule.ArrivalCity}".PadRight(30) +
                        $"{schedule.DepartureDate} | {schedule.DepartureTime}"
                    );
                }

                Console.WriteLine(new string('-', 100));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("ERROR: " + ex.Message);
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}