public class BusValidator
{
    public bool CheckIfCoachAlreadyExists(string coach)
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
}