class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("              Bus Management System          ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show All Users");
            Console.WriteLine("3. Create Bus");
            Console.WriteLine("4. Show All Bus");
            Console.WriteLine("5. Create Schedule");
            Console.WriteLine("6. Show All Schedule");
            Console.WriteLine("7. Show A Schedule Details");
            Console.WriteLine("8. Book Ticket");
            Console.WriteLine("9. Show User Tickets");
            Console.WriteLine("10. Show User Invoices");
            Console.WriteLine("11. Make Payment");
            Console.WriteLine("12. Exit");

            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.Write("Select Option: ");

            string input = Console.ReadLine() ?? "";

            if (input == "12")
                break;

            Console.WriteLine();

            if (input == "1")
            {
                Console.WriteLine("========== CREATE USER ==========");

                Console.Write("Name  : ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Email : ");
                string email = Console.ReadLine() ?? "";

                Console.Write("Phone(e.g 015...)(11 Digits) : ");
                string phone = Console.ReadLine() ?? "";

                IFormatValidator emailValidator = new EmailValidator();
                IFormatValidator phoneValidator = new PhoneValidator();
                UserService userService = new UserService(emailValidator, phoneValidator);

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
            else if (input == "2")
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

                Console.WriteLine(new string('-', 90));

                foreach (User user in users)
                {
                    Console.WriteLine(
                        user.Id.ToString().PadRight(5) +
                        user.Name.PadRight(30) +
                        user.Email.PadRight(30) +
                        user.Phone.PadRight(15) +
                        user.CreatedAt.ToString("yyyy-MM-dd")
                    );
                }

                Console.WriteLine(new string('-', 90));

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}