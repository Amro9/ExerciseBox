namespace exercisesBox.Application.Infrastruktur.Repositories;

public interface IRepository<T, A>
{
    Task<List<T>> Read();
    Task<T> ReadById(A id);
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
}
