class BookingService
{
    private readonly TicketService _ticketService;
    private readonly InvoiceService _invoiceService;

    public BookingService(TicketService ticketService, InvoiceService invoiceService)
    {
        _ticketService = ticketService;
        _invoiceService = invoiceService;
    }

    public void BookTicket(int scheduleId, int userId, string seat, Dictionary<string, BusSeatStatus> seatPlan, decimal amountDue)
    {
        Ticket ticket = _ticketService.CreateTicket(
                    scheduleId,
                    userId,
                    seat,
                    seatPlan
                );
        if (ticket != null)
        {
            _invoiceService.CreateInvoice(ticket.Id, userId, amountDue);
        }
    }
}