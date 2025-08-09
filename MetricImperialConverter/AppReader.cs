namespace MetricImperialConverter;

public static class AppReader
{
    public static string Read()
    {
        return Console.ReadLine() ?? "";
    }

    public static (string firstUnit, string secondUnit, string value) ReadUnitsAndValue()
    {
        Console.ForegroundColor= ConsoleColor.Cyan;
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Enter the first unit: ");
        Console.WriteLine("----------------------------------------");
        var firstUnit=Read();
        Console.ResetColor();
        Console.ResetColor();
        Console.ForegroundColor= ConsoleColor.DarkCyan;
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Enter the second unit: ");
        Console.WriteLine("----------------------------------------");
        Console.ResetColor();
        Console.ForegroundColor= ConsoleColor.DarkMagenta;
        var secondUnit=Read();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Enter the value: ");
        var initialValue = Read();
        Console.WriteLine("----------------------------------------");
        Console.ResetColor();
        return (firstUnit, secondUnit, initialValue);
    }
}