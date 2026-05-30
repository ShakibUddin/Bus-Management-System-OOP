public class InvoiceValidator
{
    public bool CheckIfTicketExists(int ticketId)
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
    public bool CheckIfUserExists(int userId)
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

}