namespace exercisesBox.Application.Infrastruktur.Repositories;

public interface IRepository<T, A>
{
    List<T> Read();
    T ReadById(A id);
    T Create(T entity);
    T Update(T entity);
    T Delete(T entity);
}
