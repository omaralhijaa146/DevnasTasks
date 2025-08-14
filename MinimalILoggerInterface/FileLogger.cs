using System.Text;

namespace MinimalILoggerInterface;

public class FileLogger : ILogger
{
    public void Log(string message)
    {
        using (var fileWriter= new FileStream($"{AppDomain.CurrentDomain.BaseDirectory}/log-{DateTime.Now.ToString("M-d-yy")}.txt", FileMode.Append)) 
            fileWriter.Write(Encoding.UTF8.GetBytes(message));;
    }
}