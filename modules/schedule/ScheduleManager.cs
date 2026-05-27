public class ScheduleManager
{
    public static List<Schedule> Schedules { get; set; } = [];
    public static readonly string[] availableCities = ["Dhaka", "Chittagong", "Sylhet", "Khulna"];
    public static readonly string[] availableTimeSlots = ["8 AM", "9 AM", "10 AM", "11 AM", "2 PM", "3 PM"];
}