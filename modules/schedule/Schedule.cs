public class Schedule
{
    public int Id { get; }
    public int BusId { get; }
    public string DepartureCity { get; }
    public string ArrivalCity { get; }
    public string DepartureDate { get; }
    public string DepartureTime { get; }
    public decimal TicketPrice { get; }
    public Dictionary<string, BusSeatStatus> SeatPlan { get; }
    public DateTime CreatedAt { get; }

    public Schedule(int id, int busId, string departureCity, string arrivalCity, string departureDate, string departureTime, decimal ticketPrice, Dictionary<string, BusSeatStatus> seatPlan)
    {
        Id = id;
        BusId = busId;
        DepartureCity = departureCity;
        ArrivalCity = arrivalCity;
        DepartureDate = departureDate;
        DepartureTime = departureTime;
        TicketPrice = ticketPrice;
        SeatPlan = seatPlan;
        CreatedAt = DateTime.Now;
    }
}