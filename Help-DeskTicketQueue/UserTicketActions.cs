namespace Help_DeskTicketQueue;

public static class UserTicketActions
{
    public const string AddTicket = "add";
    public const string ProcessTicket = "process";
    public const string FirstTicket = "peek";
    public const string Quit = "quit";

    public static bool CheckAction(string action)
    {
        return action==AddTicket || action==ProcessTicket || action==FirstTicket||action==Quit;
    }
}