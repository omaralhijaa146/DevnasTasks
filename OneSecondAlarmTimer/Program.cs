namespace OneSecondAlarmTimer;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("One Second Alarm Timer");
        Console.WriteLine("-----------------------");
        Console.WriteLine("***********************");
        var timer = new CustomTimer();

        timer.Tick += (seconds) =>
        {
            Console.WriteLine($"Elapsed seconds {seconds}");
        };
        timer.Start();
        Console.ReadKey();
    }
}


/*
 * One-Second Alarm Timer

Covered Topics: Delegates & Lambda Expressions

Scenario: Raise an event every second and handle it with a lambda. ([learn.microsoft.com][9])

Requirements:

Use System.Timers.Timer set to 1000 ms. ([learn.microsoft.com][10])

Expose a public event Action Tick.

Subscribe with a lambda that prints elapsed seconds.

 */