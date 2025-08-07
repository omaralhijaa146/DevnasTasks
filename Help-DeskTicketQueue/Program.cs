using System.Reflection;

namespace Help_DeskTicketQueue;

class Program
{
    private static TicketManager _ticketManager = new();
    private static Dictionary<string, Delegate> _ticketDictionary=new () 
    {
        {UserTicketActions.AddTicket,_ticketManager.AddTicket},
        {UserTicketActions.FirstTicket,_ticketManager.GetFirstTicket},
        {UserTicketActions.ProcessTicket,_ticketManager.ProcessTicket},
    };

    static void Main(string[] args)
    {

        void PrintProgramOptions()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Enter Add, Peek, or Process ticket IDs. or quit to exit the program");
            Console.WriteLine("----------------------------------------");
        }

        Console.WriteLine("Welcome to Help Desk Ticket Queue");
        PrintProgramOptions();
        
        var userInput = UserInputReader.ReadUserInput().ToLower();
        while (userInput != UserTicketActions.Quit)
        {
            
            if (UserInputChecker.TryParseUserOptionInput(userInput, out var checkedUserInput))
            {
                
                if (_ticketDictionary.TryGetValue(checkedUserInput, out var action))
                {
                    try
                    {
                        ExecuteAction(checkedUserInput, action);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (TargetInvocationException e)
                    {
                        Console.WriteLine(e.InnerException.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Unknown error happened");
                    }
                    Console.WriteLine($"Remaining Tickets {_ticketManager.TicketCount}");

                    PrintProgramOptions();

                    userInput = UserInputReader.ReadUserInput().ToLower();
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    PrintProgramOptions();
                    
                    userInput = UserInputReader.ReadUserInput().ToLower(); 
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
                PrintProgramOptions();
                userInput = UserInputReader.ReadUserInput().ToLower();
            }
            
        }
        
       
    }
    
    private static bool ExecuteAction(string userInput,Delegate action)
    { 
        Func<bool> chosenAction = userInput switch
        {
            UserTicketActions.AddTicket => () =>
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Enter ticket Id: ");
                var ticketId = UserInputReader.ReadUserInput();
                Console.WriteLine("Enter ticket Name: ");
                var ticketName = UserInputReader.ReadUserInput();
                
                var newTicket = CreateTicket(ticketId, ticketName);
                
                action.DynamicInvoke(newTicket);
                Console.WriteLine($"Ticket with Id {newTicket.Id} added");
                return true;
            },
            UserTicketActions.FirstTicket => () =>
            { 
                var ticket =action.DynamicInvoke() as Ticket;
                if (ticket != null)
                    Console.WriteLine($"First Ticket with Id {ticket.Id} and Ticket Name {ticket.Name}");
                return true;
            },
            UserTicketActions.ProcessTicket => () =>
            {
                var poppedTicket = action.DynamicInvoke() as Ticket;
                if (poppedTicket != null)
                    Console.WriteLine($"Ticket with Id {poppedTicket.Id} processed");
                return false;
            }
        };
        
        return chosenAction();
    }

    public static Ticket CreateTicket(string id, string name)
    {
        if (UserInputChecker.IsUserInputEmpty(id) || UserInputChecker.IsUserInputEmpty(name))
        {
            Console.WriteLine("Invalid ticket Id or Name Input. Try again");
            throw new ArgumentException("Invalid ticket Id or Name Input. Try again");
        }

        var newTicket = new Ticket(id: id, name: name);
        return newTicket;
    }
}

/*
 * Help-Desk Ticket Queue
Covered Topics: Collections
Scenario: Simulate a help-desk where tickets are handled in first-in, first-out order using Queue<T>. ([learn.microsoft.com][3])

Requirements:

Provide a text menu to Add, Peek, or Process ticket IDs.
Show remaining ticket count after every action.
Exit gracefully when the user types quit.
 */