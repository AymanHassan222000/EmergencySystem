using EmergencySystem.Domain.Entities;
using System.Linq.Expressions;

namespace EmergencySystem.Application.Interfaces;

public interface IGeneralRepository<T> where T : BaseEntity
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IList<T> entities);
    IQueryable<T>? Get(Expression<Func<T, bool>> predicate = null);
    void UpdateIncludeAsync(T entity, params string[] modifiedParams);
    void Delete(T entity);
    Task<bool> AnyAsync(Expression<Func<T, bool>> criteria);
    Task<int> SaveChangesAsync();   
}
