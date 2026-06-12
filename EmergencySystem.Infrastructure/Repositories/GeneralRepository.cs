using EmergencySystem.Application.Interfaces;
using EmergencySystem.Domain.Entities;
using EmergencySystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace EmergencySystem.Infrastructure.Repositories;

public class GeneralRepository<T> : IGeneralRepository<T> where T : BaseEntity
{
    private readonly EmergencySystemDbContext _context;
    protected readonly DbSet<T> _dbSet;
    public GeneralRepository(EmergencySystemDbContext context)
    {
        _context = context;    
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity) => await _context.AddAsync(entity);

    public async Task AddRangeAsync(IList<T> entities) => await _context.AddRangeAsync(entities);

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> criteria) => 
        await _dbSet.Where(m => !m.IsDeleted).AnyAsync(criteria);
    public IQueryable<T> Get(Expression<Func<T, bool>>? predicate = null) =>
        predicate is null ? _dbSet.Where(m => !m.IsDeleted) : _dbSet.Where(m => !m.IsDeleted).Where(predicate);

    public void UpdateIncludeAsync(T entity, params string[] modifiedParams)
    {
        var local = _dbSet.Local.FirstOrDefault(m => m.Id == entity.Id);

        EntityEntry entityEntry;

        if (local != null) 
        {
            _dbSet.Attach(entity);
            entityEntry = _dbSet.Entry(entity);
        }
        else
        {
            entityEntry = _context.ChangeTracker.Entries<T>().First(m => m.Entity.Id == entity.Id);
        }

        foreach (var propName in modifiedParams) 
        {
            var propInfo = entity.GetType().GetProperty(propName);
            if (propInfo != null)
            { 
                entityEntry.Property(propName).CurrentValue = propInfo.GetValue(entity);
                entityEntry.Property(propName).IsModified = true;
            }
        }
    }

    public void Delete(T entity) 
    {
        entity.IsDeleted = true;
        UpdateIncludeAsync(entity,nameof(entity.IsDeleted));
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

}
