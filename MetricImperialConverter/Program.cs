namespace MetricImperialConverter;

class Program
{
    static void Main(string[] args)
    {
        var isExit = false;
        void PrintProgramOpeningMessage()
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Welcome to Metric / Imperial Converter");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Please enter a unit code (m, km, yd, mi) and a value or press ctrl+c to exit");
            Console.WriteLine("----------------------------------------");
            Console.ResetColor();
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Supported Conversions: ");
            Console.WriteLine(
                @"
                1-KmToMi
                2-MiToKm
                3-MToYd
                4-YdToM
                5-KmToYd
                6-YdToKm");

        }

        void EndProgram(object? sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            isExit = true;
            Console.ForegroundColor= ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Exiting Program");
            Console.WriteLine("----------------------------------------");
            Environment.Exit(0);
        }
        
        Console.CancelKeyPress += EndProgram;
        PrintProgramOpeningMessage();
        var converter=new MetricImperialConverter();
        
        while (!isExit)
        {
            try
            {

                var (firstUnit, secondUnit, initialValue) = AppReader.ReadUnitsAndValue();
                if (!double.TryParse(initialValue, out var checkedValue))
                {

                    throw new ArgumentException("Invalid Value. Try again");
                }

                var convertedValue = converter.Convert(checkedValue, firstUnit, secondUnit);
                
                Console.ForegroundColor= ConsoleColor.DarkGreen;
                Console.Write($"Converted");
                Console.ForegroundColor= ConsoleColor.DarkRed;
                Console.Write($" {checkedValue} {firstUnit} to {convertedValue} {secondUnit}");
                Console.WriteLine();
                Console.ResetColor();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"{e.Message} Try again");
                Console.WriteLine("----------------------------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error happend try again");
            }
        }
        
    }
}

/*
 * Metric ? Imperial Converter
Covered Topics: Data Handling, Collections

Scenario: Build a console app that converts metres, kilometres, yards, and miles using a conversion-factor dictionary. ([learn.microsoft.com][2])

Requirements:

Store factors in a Dictionary<string,double>.

Accept a numeric value and a unit code (m, km, yd, mi).

Output both directions of conversion (metric ? imperial and vice versa).

Reject unknown units with a clear error message and retry prompt.
*/