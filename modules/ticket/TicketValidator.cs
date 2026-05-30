public class TicketValidator
{
    public bool CheckIfScheduleExists(int scheduleId)
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
    public bool CheckIfSeatExists(Dictionary<string, BusSeatStatus> seatPlan, string seat)
    {
        return seatPlan.ContainsKey(seat);
    }

}