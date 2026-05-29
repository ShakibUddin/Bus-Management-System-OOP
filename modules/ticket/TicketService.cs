
public class TicketService
{
    public Ticket CreateTicket(int scheduleId, int userId, string seat, Dictionary<string, BusSeatStatus> seatPlan)
    {
        if (!CheckIfScheduleIdExists(scheduleId)) throw new ArgumentException("No Schedule Found With This Id!");
        if (!CheckIfUserIdExists(userId)) throw new ArgumentException("No User Found With This Id!");
        if (!CheckIfSeatExists(seatPlan, seat)) throw new ArgumentException("Invalid Seat!");

        Schedule schedule = ScheduleManager.Schedules.Find(s => s.Id == scheduleId) ?? throw new ArgumentException("Schedule Not Found!");

        if (!schedule.SeatPlan.ContainsKey(seat)) throw new ArgumentException("Invalid Seat!");

        if (schedule.SeatPlan[seat] == BusSeatStatus.Confirmed)
        {
            throw new ArgumentException("Seat Already Confirmed!");
        }
        if (schedule.SeatPlan[seat] == BusSeatStatus.Booked)
        {
            throw new ArgumentException("Seat Already Booked!");
        }

        // UPDATE SEAT STATUS
        schedule.SeatPlan[seat] = BusSeatStatus.Booked;

        Ticket newTicket = new(TicketManager.Tickets.Count + 1, scheduleId, userId, seat);
        TicketManager.Tickets.Add(newTicket);
        return newTicket;
    }
    private bool CheckIfScheduleIdExists(int scheduleId)
    {
        foreach (Schedule schedule in ScheduleManager.Schedules)
        {
            if (schedule.Id == scheduleId)
            {
                return true;
            }
        }
        return false;
    }
    private bool CheckIfUserIdExists(int userId)
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
    private bool CheckIfSeatExists(Dictionary<string, BusSeatStatus> seatPlan, string seat)
    {
        return seatPlan.ContainsKey(seat);
    }
    public List<Ticket> GetTicketsByUserId(int userId)
    {
        if (userId <= 0)
        {
            throw new ArgumentException("Invalid User ID!");
        }

        List<Ticket> tickets = TicketManager.Tickets.Where(i => i.UserId == userId).ToList() ?? [];

        return tickets;
    }
    public Ticket GetTicketsById(int ticketId)
    {
        if (ticketId <= 0)
        {
            throw new ArgumentException("Invalid Ticket ID!");
        }

        var ticket = TicketManager.Tickets.Find(t => t.Id == ticketId);

        if (ticket == null) throw new ArgumentException("No Tickets Found With This Id");
        return ticket;
    }
    public static List<Ticket> GetAllTicketes()
    {
        return TicketManager.Tickets;
    }
}