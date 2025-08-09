namespace MetricImperialConverter;

public static class AppReader
{
    public static string Read()
    {
        return Console.ReadLine() ?? "";
    }

    public static (string firstUnit, string secondUnit, string value) ReadUnitsAndValue()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Enter the first unit: ");
        Console.WriteLine("----------------------------------------");
        Console.ForegroundColor= ConsoleColor.Cyan;
        var firstUnit=Read();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Enter the second unit: ");
        Console.WriteLine("----------------------------------------");
        Console.ForegroundColor= ConsoleColor.DarkCyan;
        var secondUnit=Read();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Enter the value: ");
        Console.ForegroundColor= ConsoleColor.DarkMagenta;
        var initialValue = Read();
        Console.WriteLine("----------------------------------------");
        return (firstUnit, secondUnit, initialValue);
    }
}