namespace ReceiptTotalCalculator;

public static class PriceAndQuantityReader
{
    public static string ReadPrice()
    {
        Console.WriteLine("Enter Price :");
        return Console.ReadLine() ?? "";
    }

    public static string ReadQuantity()
    {
        Console.WriteLine("Enter Quantity :");
        return Console.ReadLine() ?? "";
    }

    public static (string price, string quantity) ReadPriceAndQuantity()
    {
        Console.WriteLine("----------------------------------------");
        var uncheckedPrice = PriceAndQuantityReader.ReadPrice();
        Console.WriteLine("----------------------------------------");
        var uncheckedQuantity = PriceAndQuantityReader.ReadQuantity();
        Console.WriteLine("----------------------------------------");
        
        return (uncheckedPrice, uncheckedQuantity);
    }
    
}