using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly AppDbContext Context;

    protected RepositoryBase(AppDbContext context)
    {
        Context = context;
    }

    public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Set<TEntity>()
            .AsNoTracking()
            .OrderBy(entity => entity.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public virtual Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Context.Set<TEntity>()
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    public virtual Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Context.Set<TEntity>().AddAsync(entity, cancellationToken).AsTask();
    }

    public virtual void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }
}
