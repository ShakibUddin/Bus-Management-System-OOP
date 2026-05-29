class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Menu.Show();
            Console.Write("Select Option: ");

            string input = Console.ReadLine() ?? "";

            Console.WriteLine();

            Router.HandleRouting(input);
        }
    }
}