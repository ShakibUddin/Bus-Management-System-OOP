
public class PaymentService
{
    public void CreatePayment(int invoiceId, int userId, decimal amount, string paymentMethod)
    {
        if (!CheckIfInvoiceExists(invoiceId)) throw new ArgumentException("No Invoice Found With This Id!");
        if (!CheckIfUserExists(userId)) throw new ArgumentException("No User Found With This Id!");
        if (!CheckIfPaymentMethodExists(paymentMethod)) throw new ArgumentException("Invalid Payment Method!");

        Payment newPayment = new(PaymentManager.Payments.Count + 1, invoiceId, userId, amount, paymentMethod);
        PaymentManager.Payments.Add(newPayment);
    }
    private bool CheckIfInvoiceExists(int invoiceId)
    {
        foreach (Invoice invoice in InvoiceManager.Invoices)
        {
            if (invoice.Id == invoiceId)
            {
                return true;
            }
        }
        return false;
    }
    private bool CheckIfUserExists(int userId)
    {
        foreach (User user in UserManager.Users)
        {
            if (user.Id == userId)
            {
                return true;
            }
        }
        return false;
    }
    private bool CheckIfPaymentMethodExists(string paymentMethod)
    {
        return PaymentManager.PaymentMethods.Contains(paymentMethod);
    }

    public Payment GetPaymentById(int paymentId)
    {
        if (paymentId <= 0)
        {
            throw new ArgumentException("Invalid Payment ID!");
        }

        var payment = PaymentManager.Payments.Find(b => b.Id == paymentId) ?? null;

        if (payment == null)
        {
            throw new ArgumentException("No Payment Found With This ID!");
        }

        return payment;
    }
    public List<Payment> GetPaymentsByUserId(int userId)
    {
        if (userId <= 0)
        {
            throw new ArgumentException("Invalid User ID!");
        }

        List<Payment> payments = PaymentManager.Payments.Where(i => i.UserId == userId).ToList() ?? [];

        return payments;
    }
    public static List<Payment> GetAllPaymentes()
    {
        return PaymentManager.Payments;
    }
}