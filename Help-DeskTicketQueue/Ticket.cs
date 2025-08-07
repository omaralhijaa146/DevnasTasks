namespace Help_DeskTicketQueue;

public class Ticket
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    public Ticket(){}

    public Ticket(string id, string name)
    {
        Id = id;
        Name = name;
    }
}