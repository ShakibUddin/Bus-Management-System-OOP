public class EmailValidator : IFormatValidator
{
    public bool ValidateFormat(string email)
    {
        if (!email.Contains('@')) return false;
        return true;
    }
}