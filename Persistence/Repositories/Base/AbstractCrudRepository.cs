using Domain.DbEntities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;


namespace Persistence.Repositories.Base;

public abstract class AbstractCrudRepository<T, K> : ICrudRepository<T, K> where T : BaseEntity<K>
{
    protected readonly HospitalContext _context;

    public AbstractCrudRepository(HospitalContext context) => _context = context;

    public IQueryable<T> Queryable()
    {
        return _context.Set<T>();
    }

    public Task<T> GetByIdAsync(K id)
    {
        return Queryable().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public Task CreateAsync(T item)
    {
        _context.Set<T>().Add(item);
        return _context.SaveChangesAsync();
    }

    public Task CreateAsync(List<T> items)
    {
        _context.Set<T>().AddRange(items);
        return _context.SaveChangesAsync();
    }

    public virtual async Task RemoveAsync(K id)
    {
        var t = await GetByIdAsync(id);
        if (t != null)
        {
            _context.Set<T>().Remove(t);
        }

        await _context.SaveChangesAsync();
    }

    public Task RemoveAsync(T item)
    {
        _context.Set<T>().Remove(item);
        return _context.SaveChangesAsync();
    }

    public Task RemoveAsync(List<T> items)
    {
        _context.Set<T>().RemoveRange(items);
        return _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T item)
    {
        _context.Set<T>().Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(List<T> items)
    {
        _context.Set<T>().UpdateRange(items);
        await _context.SaveChangesAsync();
    }
}
