
using System.Globalization;

public class ScheduleService
{

    public void CreateSchedule(int busId, string busClassification, string departureCity, string arrivalCity, string departureDate, string departureTime, decimal ticketPrice)
    {
        if (!CheckIfBusExists(busId)) throw new ArgumentException("No Bus Found With This ID!");
        if (!CheckIfCityExists(departureCity)) throw new ArgumentException("Service Is Not Available In This City!");
        if (!CheckIfCityExists(arrivalCity)) throw new ArgumentException("Service Is Not Available In That City!");
        if (departureCity == arrivalCity) throw new ArgumentException("Departure And Arrival City Can Not Be Same!");
        if (!CheckIfDepartureTimeExists(departureTime)) throw new ArgumentException("Invalid Departure Time!");
        if (!CheckIfDepartureDateIsValid(departureDate)) throw new ArgumentException("Invalid Departure Date!");
        if (ticketPrice <= 0) throw new FormatException("Invalid Ticket Price");

        Dictionary<string, string> seatPlan = BusService.GetSeatPlan(busClassification);
        Schedule newSchedule = new(ScheduleManager.Schedules.Count + 1, busId, departureCity, arrivalCity, departureDate, departureTime, ticketPrice, seatPlan);
        ScheduleManager.Schedules.Add(newSchedule);
    }
    private bool CheckIfBusExists(int busId)
    {
        foreach (Bus bus in BusManager.Buses)
        {
            if (bus.Id == busId)
            {
                return true;
            }
        }
        return false;
    }
    private bool CheckIfCityExists(string city)
    {
        if (ScheduleManager.availableCities.Contains(city))
        {
            return true;
        }
        return false;
    }
    private bool CheckIfDepartureTimeExists(string departureTime)
    {
        if (ScheduleManager.availableTimeSlots.Contains(departureTime))
        {
            return true;
        }
        return false;
    }
    private bool CheckIfDepartureDateIsValid(string departureDate)
    {
        if (DateTime.TryParseExact(departureDate, "yyyy-MM-dd",
        CultureInfo.InvariantCulture,
        DateTimeStyles.None,
        out DateTime date) && date.Date >= DateTime.Today)
            return true;

        return false;
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