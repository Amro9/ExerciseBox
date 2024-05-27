namespace exerciseBox.Application.Abtraction.Repositories;

public interface IRepository<T, A>
{
    Task<IEnumerable<T>> Read();
    Task<T> ReadById(A id);
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
}
