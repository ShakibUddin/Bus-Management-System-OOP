
public class BusService
{
    public enum BusClassifications
    {
        Business,
        Economy
    }
    public enum BusSeatStatus
    {
        Confirmed,
        Available
    }
    public static Dictionary<string, int> busSeatingCapacity = new()
    {
        [BusClassifications.Business.ToString()] = 27,
        [BusClassifications.Economy.ToString()] = 36
    };
    public void CreateBus(string coach, string classification)
    {
        if (CheckIfCoachAlreadyExists(coach)) throw new ArgumentException("Coach Already Exists!");
        if (!CheckIfClassificationExists(classification)) throw new ArgumentException("Invalid Classification!");

        Bus newBus = new(BusManager.Buses.Count + 1, coach, classification, busSeatingCapacity[classification]);
        BusManager.Buses.Add(newBus);
    }
    private bool CheckIfCoachAlreadyExists(string coach)
    {
        foreach (Bus bus in BusManager.Buses)
        {
            if (bus.Coach == coach)
            {
                return true;
            }
        }
        return false;
    }
    private bool CheckIfClassificationExists(string classification)
    {
        if (busSeatingCapacity.ContainsKey(classification))
        {
            return true;
        }
        return false;
    }

    public static Dictionary<string, string> GetSeatPlan(string classification)
    {
        Dictionary<string, string> seatPlan = new();

        int seatsPerRow =
            classification == BusClassifications.Business.ToString() ? 3 : 4;

        int seatingCapacity = busSeatingCapacity[classification];
        int rows = seatingCapacity / seatsPerRow;

        char row = 'A';

        for (int i = 0; i < rows; i++)
        {
            for (int j = 1; j <= seatsPerRow; j++)
            {
                string seat = $"{row}{j}";
                seatPlan[seat] = BusSeatStatus.Available.ToString();
            }

            row++;
        }

        return seatPlan;
    }
    public Bus GetBusById(int busId)
    {
        if (busId <= 0)
        {
            throw new ArgumentException("Invalid Bus ID!");
        }

        var bus = BusManager.Buses.Find(b => b.Id == busId) ?? null;

        if (bus == null)
        {
            throw new ArgumentException("No Bus Found With This ID!");
        }

        return bus;
    }
    public static List<Bus> GetAllBuses()
    {
        return BusManager.Buses;
    }
}