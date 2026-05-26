
public class BusService
{
    public static Dictionary<string, int> busClassifications = new()
    {
        ["Business"] = 27,
        ["Economy"] = 36
    };
    public void CreateBus(string coach, string classification)
    {
        if (CheckIfCoachAlreadyExists(coach)) throw new ArgumentException("Coach Already Exists!");
        if (!CheckIfClassificationExists(classification)) throw new ArgumentException("Invalid Classification!");

        Bus newBus = new(BusManager.Buses.Count + 1, coach, classification, busClassifications[classification]);
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
        if (busClassifications.ContainsKey(classification))
        {
            return true;
        }
        return false;
    }
    public static List<Bus> GetAllBuses()
    {
        return BusManager.Buses;
    }
}