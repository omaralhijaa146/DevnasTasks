namespace MetricImperialConverter;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
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