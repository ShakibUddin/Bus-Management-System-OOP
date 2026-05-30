class Program
{
    static void Main()
    {
        IFormatValidator emailValidator = new EmailValidator();
        IFormatValidator phoneValidator = new PhoneValidator();
        UserValidator userValidator = new UserValidator();
        UserService userService = new UserService(emailValidator, phoneValidator, userValidator);
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
                    BusHandler.CreateBus();
                    break;

                case "4":
                    BusHandler.ShowAllBuses();
                    break;

                case "5":
                    ScheduleHandler.CreateSchedule();
                    break;

                case "6":
                    ScheduleHandler.ShowAllSchedules();
                    break;

                case "7":
                    ScheduleHandler.ShowScheduleDetails();
                    break;

                case "8":
                    TicketHandler.BookTicket();
                    break;

                case "9":
                    TicketHandler.ShowUserTickets();
                    break;

                case "10":
                    InvoiceHandler.ShowUserInvoices();
                    break;

                case "11":
                    PaymentHandler.CreatePayment();
                    break;

                case "12":
                    PaymentHandler.ShowUserPayments();
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