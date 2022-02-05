namespace Repository;

public interface IRepository
{
    public T Add<T>(T obj);
    public T Delete<T>(T deleteObj);
    public bool Update<T>(T oldObj, T newObj);
    public T Get<T>(Guid idObj);
    public bool TrySave();

}