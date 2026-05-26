
public class UserService
{
    private readonly IFormatValidator _emailValidator;
    private readonly IFormatValidator _phoneValidator;
    public UserService(IFormatValidator emailValidator, IFormatValidator phoneValidator)
    {
        _emailValidator = emailValidator;
        _phoneValidator = phoneValidator;
    }
    public void CreateUser(string name, string email, string phone)
    {
        if (!_emailValidator.ValidateFormat(email)) throw new FormatException("Invalid Email Adress!");
        if (!_phoneValidator.ValidateFormat(phone)) throw new FormatException("Invalid Phone Number!");

        if (CheckIfEmailAlreadyExists(email)) throw new ArgumentException("Email Already Exists");
        if (CheckIfPhoneAlreadyExists(phone)) throw new ArgumentException("Phone Already Exists");

        User newUser = new(id: UserManager.Users.Count + 1, name, email, phone);
        UserManager.Users.Add(newUser);
    }
    private bool CheckIfPhoneAlreadyExists(string phone)
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
    private bool CheckIfEmailAlreadyExists(string email)
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
    public static List<User> GetAllUsers()
    {
        return UserManager.Users;
    }
}