public class Invoice
{
    public int Id { get; }
    public int TicketId { get; }
    public int UserId { get; }
    public decimal AmountDue { get; }
    public PaymentStatus PaymentStatus { get; set; }
    public DateTime CreatedAt { get; }

    public Invoice(int id, int tiketId, int userId, decimal amountDue, PaymentStatus paymentStatus)
    {
        Id = id;
        TicketId = tiketId;
        UserId = userId;
        AmountDue = amountDue;
        PaymentStatus = paymentStatus;
        CreatedAt = DateTime.Now;
    }
}