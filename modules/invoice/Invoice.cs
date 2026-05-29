public class Invoice
{
    public int Id { get; }
    public int TicketId { get; }
    public int UserId { get; }
    public decimal AmountDue { get; }
    public string PaymentStatus { get; set; }
    public DateTime CreatedAt { get; }

    public Invoice(int id, int tiketId, int userId, decimal amountDue, string paymentStatus)
    {
        Id = id;
        TicketId = tiketId;
        UserId = userId;
        AmountDue = amountDue;
        PaymentStatus = paymentStatus;
        CreatedAt = DateTime.Now;
    }
}