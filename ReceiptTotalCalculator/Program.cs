namespace ReceiptTotalCalculator;

class Program
{
    public static void Main(string[] args)
    {

        List<(decimal price, int quantity)> _shopItems = new();
        var total = 0.0m;

        var exitProgram = false;
        Console.WriteLine("Enter price and quantity, or press arrow down to quit or enter to continue");
        
        while (!exitProgram&&Console.ReadKey(true).Key != ConsoleKey.Escape)
        {
            
            bool isValidPrice = false;
            bool isValidQuantity = false;
            decimal price;
            int quantity;
            
            
            Console.WriteLine("----------------------------------------");
            
            
                Console.WriteLine("Enter Price :");
                 isValidPrice = decimal.TryParse(Console.ReadLine(), out price);
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Enter Quantity :");
                 isValidQuantity = int.TryParse(Console.ReadLine(), out  quantity);
                Console.WriteLine("----------------------------------------");
            

            while ((!isValidPrice || !isValidQuantity) && !exitProgram)
            {
                if (!isValidPrice && isValidQuantity)
                {
                    Console.WriteLine("Invalid Price");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Enter Price :");
                    isValidPrice = decimal.TryParse(Console.ReadLine(), out price);
                }
                else if (isValidPrice && !isValidQuantity)
                {
                    Console.WriteLine("Invalid Quantity");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Enter Quantity :");
                    isValidQuantity = int.TryParse(Console.ReadLine(), out quantity);
                }
                else if (!isValidPrice && !isValidQuantity)
                {
                    Console.WriteLine("Invalid Price and Quantity");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Enter Price :");
                    isValidPrice = decimal.TryParse(Console.ReadLine(), out price);
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Enter Quantity :");
                    isValidQuantity = int.TryParse(Console.ReadLine(), out quantity);
                    Console.WriteLine("----------------------------------------");
                }
                else
                {
                    break;
                }
            }

            _shopItems.Add((price, quantity));
            total += Math.Round(price * quantity,2);

        }

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Total : " + Math.Round(total,2));
        Console.WriteLine("----------------------------------------");
        _shopItems.ForEach(item =>
            Console.WriteLine($"{Math.Round(item.price,2)} x {item.quantity} = {item.price * item.quantity}"));
        
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
