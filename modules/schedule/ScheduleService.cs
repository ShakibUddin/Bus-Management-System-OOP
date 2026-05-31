

public class ScheduleService
{
    private readonly ScheduleValidator _scheduleValidator;
    public ScheduleService(ScheduleValidator scheduleValidator)
    {
        _scheduleValidator = scheduleValidator;
    }
    public void CreateSchedule(int busId, BusClassifications busClassification, string departureCity, string arrivalCity, string departureDate, string departureTime, decimal ticketPrice)
    {
        if (!_scheduleValidator.CheckIfBusExists(busId)) throw new ArgumentException("No Bus Found With This ID!");
        if (!_scheduleValidator.CheckIfCityExists(departureCity)) throw new ArgumentException("Service Is Not Available In This City!");
        if (!_scheduleValidator.CheckIfCityExists(arrivalCity)) throw new ArgumentException("Service Is Not Available In That City!");
        if (departureCity == arrivalCity) throw new ArgumentException("Departure And Arrival City Can Not Be Same!");
        if (!_scheduleValidator.CheckIfDepartureTimeExists(departureTime)) throw new ArgumentException("Invalid Departure Time!");
        if (!_scheduleValidator.CheckIfDepartureDateIsValid(departureDate)) throw new ArgumentException("Invalid Departure Date!");
        if (ticketPrice <= 0) throw new FormatException("Invalid Ticket Price");
        if (!_scheduleValidator.checkScheduleAvailability(busId, departureDate, departureTime)) throw new ArgumentException("This Bus Is Already In Another Schedule");

        Dictionary<string, BusSeatStatus> seatPlan = BusService.GetSeatPlan(busClassification);
        Schedule newSchedule = new(ScheduleManager.Schedules.Count + 1, busId, departureCity, arrivalCity, departureDate, departureTime, ticketPrice, seatPlan);
        ScheduleManager.Schedules.Add(newSchedule);
    }
    public Schedule GetScheduleById(int scheduleId)
    {
        if (scheduleId <= 0)
        {
            throw new ArgumentException("Invalid Schedule ID!");
        }

        var schedule = ScheduleManager.Schedules.Find(s => s.Id == scheduleId) ?? null;

        if (schedule == null)
        {
            throw new ArgumentException("No Schedule Found With This ID!");
        }

        return schedule;
    }
    public static List<Schedule> GetAllSchedulees()
    {
        return ScheduleManager.Schedules;
    }
}