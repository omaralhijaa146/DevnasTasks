namespace Help_DeskTicketQueue;

public static class UserInputChecker
{
    public static bool TryParseUserOptionInput(string userInput,out string checkedUserInput)
    {
        if (!IsUserInputEmpty(userInput)&&UserTicketActions.CheckAction(userInput))
        {
            checkedUserInput=userInput;
            return true;
        }
        checkedUserInput="";
        return false;
    }
    
    public static bool IsUserInputEmpty(string userInput)=>string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput);
    
}