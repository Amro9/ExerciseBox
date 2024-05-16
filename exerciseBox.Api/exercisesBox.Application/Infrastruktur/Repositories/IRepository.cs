namespace exercisesBox.Application.Infrastruktur.Repositories;

public interface IRepository<T, K>
{
    List<T> Read();
    T ReadById(K id);
    T Create(T entity);
    T Update(T entity);
    T Delete(T entity);
}
