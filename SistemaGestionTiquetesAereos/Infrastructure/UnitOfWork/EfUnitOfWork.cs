using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Infrastructure.Context;

namespace AirlineTicketSystem.Infrastructure.UnitOfWork;

public sealed class EfUnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public EfUnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
