namespace DataTransformerwithFuncandAction;

class Program
{
    static void Main(string[] args)
    {
        var numbersList = Enumerable.Range(1, 10).ToList();
        var numbersList2 = numbersList.ToArray();
        HashSet<int> hashSet = new HashSet<int>(numbersList);
        var dataTransformer = new DataTransformer();
        Func<int,int> transformer = x => (int)Math.Pow(x, 2);
        Action<int> logger = x => Console.WriteLine($"Result = {x}");
        dataTransformer.ApplyTransformAndLog(numbersList,transformer, 
            logger);
        /*var transformedList = dataTransformer.Transform(numbersList2,transformer).ToList();
        dataTransformer.Log(transformedList,logger);*/
    }
}

/*
 * Data Transformer with Func and Action

Covered Topics: Delegates & Lambda Expressions

Scenario: A utility must transform raw integer readings, then log the results, all without hard-coding the operations.

Requirements:

Store numbers 1 – 10 in a List<int>.

Declare Func<int,int> transform that squares each value.

Declare Action<int> logger that prints "Result = <value>".

Use Select to apply the Func, then ForEach with the Action.

Verify output shows the square of every original number.

 */