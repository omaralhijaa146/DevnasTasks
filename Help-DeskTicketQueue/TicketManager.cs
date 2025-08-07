namespace Help_DeskTicketQueue;

public class TicketManager
{
    public int TicketCount => _ticketQueue.Count;
    
    private Queue<Ticket> _ticketQueue;
    public TicketManager()
    {
        _ticketQueue= new Queue<Ticket>();
    }

    public Ticket GetFirstTicket()
    {
        Ticket ticket;
        return _ticketQueue.TryPeek(out ticket)?ticket:throw new NullReferenceException("No Tickets");
    }

    public void AddTicket(Ticket ticket)
    {
        _ticketQueue.Enqueue(ticket);
    }

    public Ticket ProcessTicket()
    {
        Ticket ticket;
        return _ticketQueue.TryDequeue(out ticket)? ticket:throw new NullReferenceException("No Tickets");
    }


}