public class Ticket
{
    public int Id { get; }
    public int ScheduleId { get; }
    public int UserId { get; }
    public string Seat { get; }
    public DateTime CreatedAt { get; }

    public Ticket(int id, int scheduleId, int userId, string seat)
    {
        Id = id;
        ScheduleId = scheduleId;
        UserId = userId;
        Seat = seat;
        CreatedAt = DateTime.Now;
    }
}