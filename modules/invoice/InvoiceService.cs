
public class InvoiceService
{
    public enum PaymentStatus
    {
        Paid,
        Unpaid
    }
    public enum InvoiceSeatStatus
    {
        Confirmed,
        Available,
        Booked
    }

    public void CreateInvoice(int ticketId, int userId, decimal amountDue)
    {
        if (!CheckIfTicketExists(ticketId)) throw new ArgumentException("No Ticket Found With This Id!");
        if (!CheckIfUserExists(userId)) throw new ArgumentException("No User Found With This Id!");

        Invoice newInvoice = new(InvoiceManager.Invoices.Count + 1, ticketId, userId, amountDue, PaymentStatus.Unpaid.ToString());
        InvoiceManager.Invoices.Add(newInvoice);
    }
    private bool CheckIfTicketExists(int ticketId)
    {
        foreach (Ticket ticket in TicketManager.Tickets)
        {
            if (ticket.Id == ticketId)
            {
                return true;
            }
        }
        return false;
    }
    private bool CheckIfUserExists(int userId)
    {
        foreach (User user in UserManager.Users)
        {
            if (user.Id == userId)
            {
                return true;
            }
        }
        return false;
    }

    public Invoice GetInvoiceById(int invoiceId)
    {
        if (invoiceId <= 0)
        {
            throw new ArgumentException("Invalid Invoice ID!");
        }

        var invoice = InvoiceManager.Invoices.Find(b => b.Id == invoiceId) ?? null;

        if (invoice == null)
        {
            throw new ArgumentException("No Invoice Found With This ID!");
        }

        return invoice;
    }
    public List<Invoice> GetInvoicesByUserId(int userId)
    {
        if (userId <= 0)
        {
            throw new ArgumentException("Invalid User ID!");
        }

        List<Invoice> invoices = InvoiceManager.Invoices.Where(i => i.UserId == userId).ToList() ?? [];

        return invoices;
    }
    public static List<Invoice> GetAllInvoicees()
    {
        return InvoiceManager.Invoices;
    }
}