
public class PaymentService
{
    private readonly PaymentValidator _paymentValidator;
    public PaymentService(PaymentValidator paymentValidator)
    {
        _paymentValidator = paymentValidator;
    }
    public void CreatePayment(int invoiceId, int userId, decimal amount, string paymentMethod)
    {
        Invoice? invoice = _paymentValidator.CheckIfInvoiceExists(invoiceId);
        if (invoice == null) throw new ArgumentException("No Invoice Found With This Id!");
        if (!_paymentValidator.CheckIfUserExists(userId)) throw new ArgumentException("No User Found With This Id!");
        if (!_paymentValidator.CheckIfPaymentMethodExists(paymentMethod)) throw new ArgumentException("Invalid Payment Method!");
        if (_paymentValidator.CheckIfInvoiceIsAlreadyPaid(invoice)) throw new ArgumentException("Invoice Is Already Paid!");

        Payment newPayment = new(PaymentManager.Payments.Count + 1, invoiceId, userId, amount, paymentMethod);
        PaymentManager.Payments.Add(newPayment);
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