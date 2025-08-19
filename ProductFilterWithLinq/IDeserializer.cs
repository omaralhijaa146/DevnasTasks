namespace ProductFilterWithLinq;

public interface IDeserializer<T> where T : class, new()
{
    public List<T> Deserialize(string filePath);
}