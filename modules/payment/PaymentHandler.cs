class PaymentHandler
{
    public static void CreatePayment()
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
            invoice.PaymentStatus = PaymentStatus.Paid;

            // Update seat status
            TicketService ticketService = new TicketService();
            ScheduleService scheduleService = new ScheduleService();

            Ticket ticket = ticketService.GetTicketsById(invoice.TicketId);
            Schedule schedule = scheduleService.GetScheduleById(ticket.ScheduleId);
            schedule.SeatPlan[ticket.Seat] = BusSeatStatus.Confirmed;

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
    public static void ShowAllPayments()
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
                    payment.CreatedAt.ToString("yyyy-MM-dd hh:mm tt")
                );
            }

            Console.WriteLine(new string('-', 100));
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    public static void ShowUserPayments()
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

                Console.WriteLine(new string('-', 90));

                foreach (Payment payment in payments)
                {
                    Console.WriteLine(
                        payment.Id.ToString().PadRight(12) +
                        payment.InvoiceId.ToString().PadRight(12) +
                        $"{payment.Amount} BDT".PadRight(15) +
                        payment.PaymentMethod.PadRight(20) +
                        payment.CreatedAt.ToString("yyyy-MM-dd hh:mm tt")
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
}