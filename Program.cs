class Program
{
    static void Main()
    {
        IFormatValidator emailValidator = new EmailValidator();
        IFormatValidator phoneValidator = new PhoneValidator();
        UserValidator userValidator = new UserValidator();
        UserService userService = new UserService(emailValidator, phoneValidator, userValidator);

        BusValidator busValidator = new BusValidator();
        BusService busService = new BusService(busValidator);

        ScheduleValidator scheduleValidator = new ScheduleValidator();
        ScheduleService scheduleService = new ScheduleService(scheduleValidator);

        InvoiceService invoiceService = new InvoiceService();
        PaymentService paymentService = new PaymentService();

        TicketService ticketService = new TicketService();

        BookingService bookingService = new BookingService(ticketService, invoiceService);

        while (true)
        {
            Console.Clear();
            Menu.Show();
            Console.Write("Select Option: ");

            string input = Console.ReadLine() ?? "";

            Console.WriteLine();

            switch (input)
            {
                case "1":
                    UserHandler.CreateUser(userService);
                    break;

                case "2":
                    UserHandler.ShowAllUsers();
                    break;

                case "3":
                    BusHandler.CreateBus(busService);
                    break;

                case "4":
                    BusHandler.ShowAllBuses();
                    break;

                case "5":
                    ScheduleHandler.CreateSchedule(scheduleService, busService);
                    break;

                case "6":
                    ScheduleHandler.ShowAllSchedules();
                    break;

                case "7":
                    ScheduleHandler.ShowScheduleDetails(scheduleService, busService);
                    break;

                case "8":
                    TicketHandler.BookTicket(bookingService, scheduleService);
                    break;

                case "9":
                    TicketHandler.ShowUserTickets(ticketService, scheduleService);
                    break;

                case "10":
                    InvoiceHandler.ShowUserInvoices();
                    break;

                case "11":
                    PaymentHandler.CreatePayment(invoiceService, paymentService, ticketService, scheduleService);
                    break;

                case "12":
                    PaymentHandler.ShowUserPayments(paymentService);
                    break;

                case "13":
                    PaymentHandler.ShowAllPayments();
                    break;

                case "14":
                    return; // exit signal

                default:
                    Console.WriteLine("Invalid option!");
                    Console.ReadKey();
                    break;
            }

        }
    }
}