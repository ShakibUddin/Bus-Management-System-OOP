public class PhoneValidator : IFormatValidator
{
    public bool ValidateFormat(string phone)
    {
        if (phone.Length != 11) return false;
        return true;
    }
}