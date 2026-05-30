public class UserValidator
{
    public bool CheckIfPhoneAlreadyExists(string phone)
    {
        foreach (User user in UserManager.Users)
        {
            if (user.Phone == phone)
            {
                return true;
            }
        }
        return false;
    }
    public bool CheckIfEmailAlreadyExists(string email)
    {
        foreach (User user in UserManager.Users)
        {
            if (user.Email == email)
            {
                return true;
            }
        }
        return false;
    }
}