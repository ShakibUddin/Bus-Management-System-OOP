public class PaymentValidator
{
    public bool CheckIfInvoiceIsAlreadyPaid(Invoice invoice)
    {
        return invoice.PaymentStatus == PaymentStatus.Paid;
    }
    public Invoice? CheckIfInvoiceExists(int invoiceId)
    {
        foreach (Invoice invoice in InvoiceManager.Invoices)
        {
            if (invoice.Id == invoiceId)
            {
                return invoice;
            }
        }
        return null;
    }
    public bool CheckIfUserExists(int userId)
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
    public bool CheckIfPaymentMethodExists(string paymentMethod)
    {
        return PaymentManager.PaymentMethods.Contains(paymentMethod);
    }

}