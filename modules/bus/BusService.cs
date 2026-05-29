
public class BusService
{
    public static Dictionary<BusClassifications, int> busSeatingCapacity = new()
    {
        [BusClassifications.Business] = 27,
        [BusClassifications.Economy] = 36
    };
    public void CreateBus(string coach, string classification)
    {
        if (CheckIfCoachAlreadyExists(coach)) throw new ArgumentException("Coach Already Exists!");
        if (!Enum.TryParse(classification, out BusClassifications busClassifications)) throw new ArgumentException("Invalid Classification!");

        Bus newBus = new(BusManager.Buses.Count + 1, coach, busClassifications, busSeatingCapacity[busClassifications]);
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

    public static Dictionary<string, BusSeatStatus> GetSeatPlan(BusClassifications classification)
    {
        Dictionary<string, BusSeatStatus> seatPlan = new();

        int seatsPerRow = classification == BusClassifications.Business ? 3 : 4;

        int seatingCapacity = busSeatingCapacity[classification];
        int rows = seatingCapacity / seatsPerRow;

        char row = 'A';

        for (int i = 0; i < rows; i++)
        {
            for (int j = 1; j <= seatsPerRow; j++)
            {
                string seat = $"{row}{j}";
                seatPlan[seat] = BusSeatStatus.Available;
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