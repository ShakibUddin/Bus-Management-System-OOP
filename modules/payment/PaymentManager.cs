public class PaymentManager
{
    public static readonly List<string> PaymentMethods = ["MobileBanking", "Card"];
    public static List<Payment> Payments { get; set; } = [];
}