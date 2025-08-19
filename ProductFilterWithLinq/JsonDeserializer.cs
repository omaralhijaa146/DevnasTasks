using System.Text.Json;

namespace ProductFilterWithLinq;

public class JsonDeserializer<T> :IDeserializer<T> where T : class, new()
{
    public List<T> Deserialize(string filePath)
    {
        var json = ReadFile(filePath);
        
        var items = JsonSerializer.Deserialize<List<T>>(json);
        return items?? new List<T>();
    }

    private string ReadFile(string filePath)
    {
        string? json;
        try
        {
            using (var stream = new StreamReader(filePath))
            {
                json = stream.ReadToEnd();
            }

            if (string.IsNullOrEmpty(json))
                throw new ArgumentException("Invalid JSON");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        return json;
    }
}