using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class CabinConfigurationRepository : RepositoryBase<CabinConfiguration>, ICabinConfiguration
{
    public CabinConfigurationRepository(AppDbContext context)
        : base(context)
    {
    }
}
