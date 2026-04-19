namespace Pure.Library.Repository.Interfaces;

public interface IDbDataReaderMapper<T, R> where T : class, new()
{
    public T Map(R reader, T? entity);
}
