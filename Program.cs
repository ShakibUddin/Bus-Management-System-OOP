class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("              Bus Management System          ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show All Users");
            Console.WriteLine("3. Create Bus");
            Console.WriteLine("4. Show All Bus");
            Console.WriteLine("5. Create Schedule");
            Console.WriteLine("6. Show All Schedule");
            Console.WriteLine("7. Show A Schedule Details");
            Console.WriteLine("8. Book Ticket");
            Console.WriteLine("9. Show User Tickets");
            Console.WriteLine("10. Show User Invoices");
            Console.WriteLine("11. Make Payment");
            Console.WriteLine("12. Show User Payments");
            Console.WriteLine("13. Show All Payments");
            Console.WriteLine("14. Exit");

            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.Write("Select Option: ");

            string input = Console.ReadLine() ?? "";

            if (input == "14")
                break;

            Console.WriteLine();

            if (input == "1")
            {
                Console.WriteLine("========== CREATE USER ==========");

                Console.Write("Name  : ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Email : ");
                string email = Console.ReadLine() ?? "";

                Console.Write("Phone(e.g 015...)(11 Digits) : ");
                string phone = Console.ReadLine() ?? "";

                IFormatValidator emailValidator = new EmailValidator();
                IFormatValidator phoneValidator = new PhoneValidator();
                UserService userService = new UserService(emailValidator, phoneValidator);

                try
                {
                    userService.CreateUser(name, email, phone);
                    Console.WriteLine();
                    Console.WriteLine("User created successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR: " + ex.Message);
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            else if (input == "2")
            {
                var users = UserService.GetAllUsers();

                Console.WriteLine("========== ALL USERS ==========");
                Console.WriteLine($"Total Users: {users.Count}");
                Console.WriteLine();

                Console.WriteLine(
                    "Id".PadRight(5) +
                    "Name".PadRight(30) +
                    "Email".PadRight(30) +
                    "Phone".PadRight(15) +
                    "Created At"
                );

                Console.WriteLine(new string('-', 90));

                foreach (User user in users)
                {
                    Console.WriteLine(
                        user.Id.ToString().PadRight(5) +
                        user.Name.PadRight(30) +
                        user.Email.PadRight(30) +
                        user.Phone.PadRight(15) +
                        user.CreatedAt.ToString("yyyy-MM-dd")
                    );
                }

                Console.WriteLine(new string('-', 90));

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            else if (input == "3")
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
            else if (input == "4")
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

                Console.WriteLine(new string('-', 90));

                foreach (Bus bus in buses)
                {
                    Console.WriteLine(
                        bus.Id.ToString().PadRight(5) +
                        bus.Coach.PadRight(30) +
                        bus.Classification.PadRight(30) +
                        bus.TotalSeatingCapacity.ToString().PadRight(30) +
                        bus.CreatedAt.ToString("yyyy-MM-dd")
                    );
                }

                Console.WriteLine(new string('-', 90));

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            else if (input == "5")
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
                BusService busService = new BusService();
                Bus bus = busService.GetBusById(busIdNumber);


                try
                {
                    ScheduleService scheduleService = new ScheduleService();
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
            else if (input == "6")
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
                       schedule.CreatedAt.ToString("yyyy-MM-dd")
                   );
                }

                Console.WriteLine(new string('=', 70));
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            else if (input == "7")
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
                ScheduleService scheduleService = new ScheduleService();
                Schedule schedule = scheduleService.GetScheduleById(scheduleIdNumber);

                Console.WriteLine("========== SCHEDULE DETAILS ==========\n");

                BusService busService = new BusService();
                Bus bus = busService.GetBusById(schedule.BusId);

                int seatsPerRow =
                    bus.Classification == BusService.BusClassifications.Business.ToString() ? 3 : 4;

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
                            schedule.SeatPlan[seat1] == BusService.BusSeatStatus.Confirmed.ToString()
                            ? "✓" : schedule.SeatPlan[seat1] == BusService.BusSeatStatus.Booked.ToString() ? "X" : " ";

                        string symbol2 =
                            schedule.SeatPlan[seat2] == BusService.BusSeatStatus.Confirmed.ToString()
                            ? "✓" : schedule.SeatPlan[seat2] == BusService.BusSeatStatus.Booked.ToString() ? "X" : " ";

                        string symbol3 =
                            schedule.SeatPlan[seat3] == BusService.BusSeatStatus.Confirmed.ToString()
                            ? "✓" : schedule.SeatPlan[seat3] == BusService.BusSeatStatus.Booked.ToString() ? "X" : " ";

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
                            schedule.SeatPlan[seat1] == BusService.BusSeatStatus.Confirmed.ToString()
                            ? "✓" : schedule.SeatPlan[seat1] == BusService.BusSeatStatus.Booked.ToString() ? "X" : " ";

                        string symbol2 =
                            schedule.SeatPlan[seat2] == BusService.BusSeatStatus.Confirmed.ToString()
                            ? "✓" : schedule.SeatPlan[seat2] == BusService.BusSeatStatus.Booked.ToString() ? "X" : " ";

                        string symbol3 =
                            schedule.SeatPlan[seat3] == BusService.BusSeatStatus.Confirmed.ToString()
                            ? "✓" : schedule.SeatPlan[seat3] == BusService.BusSeatStatus.Booked.ToString() ? "X" : " ";

                        string symbol4 =
                            schedule.SeatPlan[seat4] == BusService.BusSeatStatus.Confirmed.ToString()
                            ? "✓" : schedule.SeatPlan[seat4] == BusService.BusSeatStatus.Booked.ToString() ? "X" : " ";

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
            else if (input == "8")
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

                    TicketService ticketService = new TicketService();
                    InvoiceService invoiceService = new InvoiceService();
                    BookingService bookingService = new BookingService(ticketService, invoiceService);
                    ScheduleService scheduleService = new ScheduleService();
                    Dictionary<string, string> seatPlan = scheduleService.GetScheduleById(scheduleIdNumber).SeatPlan;

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
            else if (input == "9")
            {
                Console.WriteLine("========== USER TICKETS ==========\n");

                Console.Write("User Id : ");
                string userId = Console.ReadLine() ?? "";

                try
                {
                    int userIdNumber = int.Parse(userId);

                    TicketService ticketService = new TicketService();
                    ScheduleService scheduleService = new ScheduleService();

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

                        Console.WriteLine(new string('-', 90));

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

                        Console.WriteLine(new string('-', 90));
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
            else if (input == "10")
            {
                Console.WriteLine("========== USER INVOICES ==========\n");

                Console.Write("User Id : ");
                string userId = Console.ReadLine() ?? "";

                try
                {
                    int userIdNumber = int.Parse(userId);

                    InvoiceService invoiceService = new InvoiceService();

                    List<Invoice> invoices =
                        invoiceService.GetInvoicesByUserId(userIdNumber);

                    if (invoices.Count == 0)
                    {
                        Console.WriteLine("\nNo Invoices Found!");
                    }
                    else
                    {
                        Console.WriteLine();

                        Console.WriteLine(
                            "InvoiceId".PadRight(12) +
                            "TicketId".PadRight(12) +
                            "Amount".PadRight(15) +
                            "Payment Status"
                        );

                        Console.WriteLine(new string('-', 60));

                        foreach (Invoice invoice in invoices)
                        {
                            Console.WriteLine(
                                invoice.Id.ToString().PadRight(12) +
                                invoice.TicketId.ToString().PadRight(12) +
                                $"{invoice.AmountDue} BDT".PadRight(15) +
                                invoice.PaymentStatus
                            );
                        }

                        Console.WriteLine(new string('-', 60));
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
            else if (input == "11")
            {
                Console.WriteLine("========== MAKE PAYMENT ==========\n");

                Console.Write("Invoice Id : ");
                string invoiceId = Console.ReadLine() ?? "";

                Console.Write("User Id     : ");
                string userId = Console.ReadLine() ?? "";

                Console.Write($"Payment Method({String.Join(", ", PaymentManager.PaymentMethods)}): ");
                string paymentMethod = Console.ReadLine() ?? "";

                try
                {
                    int invoiceIdNumber = int.Parse(invoiceId);
                    int userIdNumber = int.Parse(userId);

                    // Get amount
                    InvoiceService invoiceService = new InvoiceService();
                    Invoice invoice = invoiceService.GetInvoiceById(invoiceIdNumber);
                    decimal amount = invoice.AmountDue;

                    // create payment
                    PaymentService paymentService = new PaymentService();
                    paymentService.CreatePayment(invoiceIdNumber, userIdNumber, amount, paymentMethod);

                    // Update invoice
                    invoice.PaymentStatus = InvoiceService.PaymentStatus.Paid.ToString();

                    // Update seat status
                    TicketService ticketService = new TicketService();
                    ScheduleService scheduleService = new ScheduleService();

                    Ticket ticket = ticketService.GetTicketsById(invoice.TicketId);
                    Schedule schedule = scheduleService.GetScheduleById(ticket.ScheduleId);
                    schedule.SeatPlan[ticket.Seat] = BusService.BusSeatStatus.Confirmed.ToString();

                    Console.WriteLine();
                    Console.WriteLine("Payment Created Successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR: " + ex.Message);
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            else if (input == "12")
            {
                Console.WriteLine("========== USER PAYMENTS ==========\n");

                Console.Write("User Id : ");
                string userId = Console.ReadLine() ?? "";

                try
                {
                    int userIdNumber = int.Parse(userId);

                    PaymentService paymentService = new PaymentService();

                    List<Payment> payments =
                        paymentService.GetPaymentsByUserId(userIdNumber);

                    if (payments.Count == 0)
                    {
                        Console.WriteLine("\nNo Payments Found!");
                    }
                    else
                    {
                        Console.WriteLine();

                        Console.WriteLine(
                            "PaymentId".PadRight(12) +
                            "InvoiceId".PadRight(12) +
                            "Amount".PadRight(15) +
                            "Method".PadRight(20) +
                            "Created At"
                        );

                        Console.WriteLine(new string('-', 80));

                        foreach (Payment payment in payments)
                        {
                            Console.WriteLine(
                                payment.Id.ToString().PadRight(12) +
                                payment.InvoiceId.ToString().PadRight(12) +
                                $"{payment.Amount} BDT".PadRight(15) +
                                payment.PaymentMethod.PadRight(20) +
                                payment.CreatedAt.ToString("yyyy-MM-dd")
                            );
                        }

                        Console.WriteLine(new string('-', 80));
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
            else if (input == "13")
            {
                Console.WriteLine("========== ALL PAYMENTS ==========\n");

                List<Payment> payments =
                    PaymentService.GetAllPaymentes();

                if (payments.Count == 0)
                {
                    Console.WriteLine("No Payments Found!");
                }
                else
                {
                    Console.WriteLine(
                        "PaymentId".PadRight(12) +
                        "InvoiceId".PadRight(12) +
                        "UserId".PadRight(10) +
                        "Amount".PadRight(15) +
                        "Method".PadRight(20) +
                        "Created At"
                    );

                    Console.WriteLine(new string('-', 100));

                    foreach (Payment payment in payments)
                    {
                        Console.WriteLine(
                            payment.Id.ToString().PadRight(12) +
                            payment.InvoiceId.ToString().PadRight(12) +
                            payment.UserId.ToString().PadRight(10) +
                            $"{payment.Amount} BDT".PadRight(15) +
                            payment.PaymentMethod.PadRight(20) +
                            payment.CreatedAt.ToString("yyyy-MM-dd")
                        );
                    }

                    Console.WriteLine(new string('-', 100));
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}