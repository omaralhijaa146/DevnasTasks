namespace DataTransformerwithFuncandAction;

public class DataTransformer
{
    
    public IEnumerable<int> Transform(IEnumerable<int> numbers,Func<int, int> transfomer)
    {
        return numbers.Select(x => transfomer(x));
    }
    
    public void Log(IEnumerable<int> numbers,Action<int> logger)
    {
        numbers.ToList().ForEach(x => logger(x));
    }

    public void ApplyTransformAndLog(IEnumerable<int> numbers,Func<int, int> transfomer, Action<int> logger)
    {
        IEnumerable<int> transformedNumbers = Transform(numbers,transfomer).ToList(); 
        Log(transformedNumbers,logger);
    }
}