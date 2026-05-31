using System.Globalization;
using System.Xml.Serialization;

public class ScheduleValidator
{
    public bool CheckIfBusExists(int busId)
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
    public bool CheckIfCityExists(string city)
    {
        if (ScheduleManager.availableCities.Contains(city))
        {
            return true;
        }
        return false;
    }
    public bool CheckIfDepartureTimeExists(string departureTime)
    {
        if (ScheduleManager.availableTimeSlots.Contains(departureTime))
        {
            return true;
        }
        return false;
    }
    public bool CheckIfDepartureDateIsValid(string departureDate)
    {
        if (DateTime.TryParseExact(departureDate, "yyyy-MM-dd",
        CultureInfo.InvariantCulture,
        DateTimeStyles.None,
        out DateTime date) && date.Date >= DateTime.Today)
            return true;

        return false;
    }

    public bool checkScheduleAvailability(int busId, string departureDate, string departureTime)
    {
        foreach (Schedule schedule in ScheduleManager.Schedules)
        {
            if (schedule.BusId == busId && schedule.DepartureDate == departureDate && schedule.DepartureTime == departureTime)
            {
                return false;
            }
        }
        return true;
    }
}