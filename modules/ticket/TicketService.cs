
public class TicketService
{
    public void CreateTicket(int scheduleId, int userId, string seat, Dictionary<string, string> seatPlan)
    {
        if (!CheckIfScheduleIdExists(scheduleId)) throw new ArgumentException("No Schedule Found With This Id!");
        if (!CheckIfUserIdExists(userId)) throw new ArgumentException("No User Found With This Id!");
        if (!CheckIfSeatExists(seatPlan, seat)) throw new ArgumentException("Invalid Seat!");

        Schedule schedule = ScheduleManager.Schedules.Find(s => s.Id == scheduleId) ?? throw new ArgumentException("Schedule Not Found!");

        if (!schedule.SeatPlan.ContainsKey(seat)) throw new ArgumentException("Invalid Seat!");

        if (schedule.SeatPlan[seat] == BusService.BusSeatStatus.Confirmed.ToString())
        {
            throw new ArgumentException("Seat Already Confirmed!");
        }
        if (schedule.SeatPlan[seat] == BusService.BusSeatStatus.Booked.ToString())
        {
            throw new ArgumentException("Seat Already Booked!");
        }

        // UPDATE SEAT STATUS
        schedule.SeatPlan[seat] = BusService.BusSeatStatus.Booked.ToString();

        Ticket newTicket = new(TicketManager.Tickets.Count + 1, scheduleId, userId, seat);
        TicketManager.Tickets.Add(newTicket);
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
    private bool CheckIfSeatExists(Dictionary<string, string> seatPlan, string seat)
    {
        return seatPlan.ContainsKey(seat);
    }

    public static List<Ticket> GetAllTicketes()
    {
        return TicketManager.Tickets;
    }
}