class UserHandler
{
    public static void CreateUser(UserService userService)
    {
        Console.WriteLine("========== CREATE USER ==========");

        string name = InputHelper.ReadString("Name  : ") ?? "";

        string email = InputHelper.ReadString("Email : ") ?? "";

        string phone = InputHelper.ReadPhoneNumber("Phone(e.g 015...)(11 Digits) : ") ?? "";

        try
        {
            userService.CreateUser(name, email, phone);
            Console.WriteLine();
            Console.WriteLine("User created successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("ERROR: " + ex.Message);
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public static void ShowAllUsers()
    {
        var users = UserService.GetAllUsers();

        Console.WriteLine("========== ALL USERS ==========");
        Console.WriteLine($"Total Users: {users.Count}");
        Console.WriteLine();

        Console.WriteLine(
            "Id".PadRight(5) +
            "Name".PadRight(30) +
            "Email".PadRight(30) +
            "Phone".PadRight(15) +
            "Created At"
        );

        Console.WriteLine(new string('-', 100));

        foreach (User user in users)
        {
            Console.WriteLine(
                user.Id.ToString().PadRight(5) +
                user.Name.PadRight(30) +
                user.Email.PadRight(30) +
                user.Phone.PadRight(15) +
                user.CreatedAt.ToString("yyyy-MM-dd hh:mm tt")
            );
        }

        Console.WriteLine(new string('-', 100));

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}