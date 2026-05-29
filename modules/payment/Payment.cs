public class Payment
{
    public int Id { get; }
    public int InvoiceId { get; }
    public int UserId { get; }
    public decimal Amount { get; }
    public string PaymentMethod { get; }
    public DateTime CreatedAt { get; }


    public Payment(int id, int invoiceId, int userId, decimal amount, string paymentMethod)
    {
        Id = id;
        InvoiceId = invoiceId;
        UserId = userId;
        Amount = amount;
        PaymentMethod = paymentMethod;
        CreatedAt = DateTime.Now;
    }
}