namespace InMemoryGenericRepository;

public class GenericRepository<T> : IGenericRepository<T>
{
    
    private List<T> _entities = new();

    public GenericRepository(List<T> entities)
    {
        _entities = entities;
    }
    
    public Task Add(T entity)
    {
        var modifiedEntities = _entities.ToList();
        modifiedEntities.Add(entity);
        _entities=modifiedEntities;
        return Task.CompletedTask;
    }

    public Task<List<T>> GetAll()
    {
        return Task.FromResult(_entities.Select(x=>x).ToList());
    }

    public Task<T?> Find(Func<T,bool> condition)
    {
        return  Task.FromResult(_entities.FirstOrDefault(condition));
    }
}