
public class UserService
{
    private readonly IFormatValidator _emailValidator;
    private readonly IFormatValidator _phoneValidator;
    private readonly UserValidator _userValidator;
    public UserService(IFormatValidator emailValidator, IFormatValidator phoneValidator, UserValidator userValidator)
    {
        _emailValidator = emailValidator;
        _phoneValidator = phoneValidator;
        _userValidator = userValidator;
    }
    public void CreateUser(string name, string email, string phone)
    {
        if (!_emailValidator.ValidateFormat(email)) throw new FormatException("Invalid Email Address!");
        if (!_phoneValidator.ValidateFormat(phone)) throw new FormatException("Invalid Phone Number!");

        if (_userValidator.CheckIfEmailAlreadyExists(email)) throw new ArgumentException("Email Already Exists");
        if (_userValidator.CheckIfPhoneAlreadyExists(phone)) throw new ArgumentException("Phone Already Exists");

        User newUser = new(id: UserManager.Users.Count + 1, name, email, phone);
        UserManager.Users.Add(newUser);
    }
    public static List<User> GetAllUsers()
    {
        return UserManager.Users;
    }
}