public static class InputHelper
{
    public static string ReadString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(input) &&
                !input.All(char.IsDigit))
            {
                return input;
            }

            Console.WriteLine("Invalid input. Please enter text.");
        }
    }

    public static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }

            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    public static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            if (decimal.TryParse(Console.ReadLine(), out decimal value))
            {
                return value;
            }

            Console.WriteLine("Invalid input. Please enter a decimal.");
        }
    }
    public static string ReadPhoneNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string phone = Console.ReadLine()?.Trim() ?? "";

            if (phone.Length == 11 &&
                phone.StartsWith("01") &&
                phone.All(char.IsDigit))
            {
                return phone;
            }

            Console.WriteLine("Invalid phone number. Please enter an 11-digit number starting with 01.");
        }
    }
    public static string ReadStringWithDigits(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim() ?? "";

            if (!string.IsNullOrWhiteSpace(input) &&
                input.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
            {
                return input;
            }

            Console.WriteLine("Invalid input. Only letters and digits are allowed.");
        }
    }
}