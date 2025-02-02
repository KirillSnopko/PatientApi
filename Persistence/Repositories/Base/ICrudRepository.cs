using Domain.DbEntities;

namespace Persistence.Repositories.Base;

public interface ICrudRepository<T, K> where T : BaseEntity<K>
{
    IQueryable<T> Queryable();

    Task<T> GetByIdAsync(K id);

    Task CreateAsync(T item);

    Task CreateAsync(List<T> items);

    Task UpdateAsync(T item);

    Task UpdateAsync(List<T> items);

    Task RemoveAsync(K id);

    Task RemoveAsync(T item);

    Task RemoveAsync(List<T> items);
}
