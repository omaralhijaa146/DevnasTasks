namespace ReceiptTotalCalculator;

class Program
{
    public static ConsoleKeyInfo ReadExitKey()
    {
        var key = Console.ReadKey(true);
        return key;
    }
    public static bool CloseProgram()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Enter price and quantity, or press any key to quit or press enter to continue");
        var key = ReadExitKey();
        return key.Key!=ConsoleKey.Enter;
    }
    
    public static void Main(string[] args)
    {
        void PrintReceipt(List<(decimal price,int quantity)> shopItems,decimal total)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Reciept");
            Console.WriteLine("----------------------------------------");
            shopItems.ForEach(item =>
                Console.WriteLine($"{Math.Round(item.price,2)} x {item.quantity} = {item.price * item.quantity}"));
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Total = {Math.Round(total,2)}");
            Console.WriteLine("----------------------------------------");
        }
        
        var isProgramClosed = CloseProgram();
        if (isProgramClosed)
        {
            return;
        }
       
        List<(decimal price, int quantity)> _shopItems = new();
        
        var total = 0.0m;
       
        try
        {

            var (price, quantity) = CheckReceiptItem();
            if (price > -1 && quantity > -1)
            {
                total += price * quantity;
                _shopItems.Add((price, quantity));
            }
        }
        catch (InvalidPriceOrQuantityException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unknown error happened {e.Message}");
        }

        if (!isProgramClosed)
        {
            PrintReceipt(_shopItems, total);   
        }

    }
    
    public static (decimal price,int quantity) CheckReceiptItem()
    {
        var exitProgram = false;
        decimal checkedPrice=-1;
        int checkedQuantity=-1;
        while (!exitProgram)
        {

            bool isValidPrice = false;
            bool isValidQuantity = false;
            
            var (uncheckedPrice, uncheckedQuantity) = PriceAndQuantityReader.ReadPriceAndQuantity();
            isValidPrice = decimal.TryParse(uncheckedPrice, out checkedPrice);
            isValidQuantity = int.TryParse(uncheckedQuantity, out checkedQuantity);


            while ((!isValidPrice || !isValidQuantity) && !exitProgram)
            {
                if (!isValidPrice && isValidQuantity)
                {
                    Console.WriteLine("Invalid Price");
                    
                    isValidPrice = decimal.TryParse(PriceAndQuantityReader.ReadPrice(), out checkedPrice);
                }
                else if (isValidPrice && !isValidQuantity)
                {
                    Console.WriteLine("Invalid Quantity");
                    
                    isValidQuantity = int.TryParse(PriceAndQuantityReader.ReadQuantity(), out checkedQuantity);
                }
                else if (!isValidPrice && !isValidQuantity)
                {
                    Console.WriteLine("Invalid Price and Quantity");
                    var (newUncheckedPrice, newUncheckedQuantity) = PriceAndQuantityReader.ReadPriceAndQuantity();
                    isValidPrice = decimal.TryParse(newUncheckedPrice, out checkedPrice);
                    isValidQuantity = int.TryParse(newUncheckedQuantity, out checkedQuantity);
                    Console.WriteLine("----------------------------------------");
                }
                else if (isValidPrice && isValidQuantity)
                {
                    break;
                }
                
            }

            exitProgram=CloseProgram();
        } 
        
        if(checkedPrice<0||checkedQuantity<0)
            throw new InvalidPriceOrQuantityException("Invalid Price and Quantity Inputs");
        
        return (checkedPrice, checkedQuantity);
    }
}


/*
 * Receipt Total Calculator
Covered Topics: Basic Syntax and Structure, Memory and Variable Handling

Scenario: A corner-shop cashier needs a console tool that reads unit price and quantity, then prints a neatly formatted receipt. ([learn.microsoft.com][1])

Requirements:
Prompt for price and quantity, converting the strings with decimal.TryParse in a loop until valid input is entered. ([learn.microsoft.com][1])

Multiply values and print the total with two-decimal currency formatting.

Encapsulate all logic in Main() plus one helper method, following PascalCase for method names.
 */
