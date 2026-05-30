class InvoiceHandler
{
    public static void ShowUserInvoices(InvoiceService invoiceService)
    {
        Console.WriteLine("========== USER INVOICES ==========\n");

        Console.Write("User Id : ");
        string userId = Console.ReadLine() ?? "";

        try
        {
            int userIdNumber = int.Parse(userId);

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

                Console.WriteLine(new string('-', 70));

                foreach (Invoice invoice in invoices)
                {
                    Console.WriteLine(
                        invoice.Id.ToString().PadRight(12) +
                        invoice.TicketId.ToString().PadRight(12) +
                        $"{invoice.AmountDue} BDT".PadRight(15) +
                        invoice.PaymentStatus
                    );
                }

                Console.WriteLine(new string('-', 70));
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