namespace InMemoryGenericRepository;

public interface IGenericRepository<T>
{
    Task Add(T entity);
    Task<List<T>> GetAll();
    Task<T?> Find(Func<T,bool> condition);
}