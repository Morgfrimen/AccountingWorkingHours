namespace Repository.Xml;

public sealed class XmlRepository : IRepository
{
    public T Add<T>(T obj) => throw new NotImplementedException();

    public T Delete<T>(T deleteObj) => throw new NotImplementedException();

    public bool Update<T>(T oldObj, T newObj) => throw new NotImplementedException();

    public T Get<T>(Guid idObj) => throw new NotImplementedException();
    public bool TrySave() => throw new NotImplementedException();
}