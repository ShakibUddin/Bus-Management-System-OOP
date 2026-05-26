public class Bus
{
    public int Id { get; }
    public string Coach { get; }
    public string Classification { get; }
    public int TotalSeatingCapacity { get; }
    public DateTime CreatedAt { get; }

    public Bus(int id, string coach, string classification, int totalSeatingCapacity)
    {
        Id = id;
        Coach = coach;
        Classification = classification;
        TotalSeatingCapacity = totalSeatingCapacity;
        CreatedAt = DateTime.Now;
    }
}