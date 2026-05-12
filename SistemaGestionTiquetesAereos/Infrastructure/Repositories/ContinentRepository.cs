using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class ContinentRepository : IContinent
{
    private readonly AppDbContext _context;

    public ContinentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Continent>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Continents
            .AsNoTracking()
            .OrderBy(continent => continent.Name)
            .ToListAsync(cancellationToken);
    }

    public Task<Continent?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _context.Continents
            .FirstOrDefaultAsync(continent => continent.Id == id, cancellationToken);
    }

    public Task AddAsync(Continent continent, CancellationToken cancellationToken = default)
    {
        return _context.Continents.AddAsync(continent, cancellationToken).AsTask();
    }

    public void Update(Continent continent)
    {
        _context.Continents.Update(continent);
    }

    public void Delete(Continent continent)
    {
        _context.Continents.Remove(continent);
    }

    public Task<bool> ExistsByNameAsync(
        string name,
        Guid? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        var normalizedName = name.Trim();

        return _context.Continents.AnyAsync(
            continent => continent.Name == normalizedName && (!excludeId.HasValue || continent.Id != excludeId.Value),
            cancellationToken);
    }
}
