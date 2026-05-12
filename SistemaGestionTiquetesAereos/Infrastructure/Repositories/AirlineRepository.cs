using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class AirlineRepository : IAirline
{
    private readonly AppDbContext _context;

    public AirlineRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Airline>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Airlines
            .AsNoTracking()
            .OrderBy(airline => airline.Name)
            .ToListAsync(cancellationToken);
    }

    public Task<Airline?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _context.Airlines
            .FirstOrDefaultAsync(airline => airline.Id == id, cancellationToken);
    }

    public Task AddAsync(Airline airline, CancellationToken cancellationToken = default)
    {
        return _context.Airlines.AddAsync(airline, cancellationToken).AsTask();
    }

    public void Update(Airline airline)
    {
        _context.Airlines.Update(airline);
    }

    public void Delete(Airline airline)
    {
        _context.Airlines.Remove(airline);
    }

    public Task<bool> ExistsByIataCodeAsync(
        string iataCode,
        Guid? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        var normalizedCode = iataCode.Trim().ToUpperInvariant();

        return _context.Airlines.AnyAsync(
            airline => airline.IataCode == normalizedCode && (!excludeId.HasValue || airline.Id != excludeId.Value),
            cancellationToken);
    }
}
