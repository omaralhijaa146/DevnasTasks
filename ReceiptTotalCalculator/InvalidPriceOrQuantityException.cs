namespace ReceiptTotalCalculator;

public class InvalidPriceOrQuantityException:Exception
{
    public InvalidPriceOrQuantityException(string message):base(message)
    {
        
    }
}