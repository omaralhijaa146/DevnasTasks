using System.Reflection;

namespace MinimalILoggerInterface;

class Program
{
    static void Main(string[] args)
    {
        var consoleLogger = new ConsoleLogger();
        var fileLogger = new FileLogger();
        Log(consoleLogger, "Console Logger");
        Log(fileLogger, "File Logger");
        Console.ReadLine();
    }

    static void Log(ILogger logger, string message)
    {
        logger.Log(message);
    }
}

/*
 * Minimal ILogger Interface

Covered Topics: Interfaces and Abstract Classes

Scenario: Decouple logging by coding against an interface.

Requirements:

Declare void Log(string message) in an ILogger interface.

Implement ConsoleLogger and FileLogger.

Write a demo that logs through an ILogger reference only.

 */
