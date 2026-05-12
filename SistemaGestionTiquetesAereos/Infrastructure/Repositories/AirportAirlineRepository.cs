using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class AirportAirlineRepository : RepositoryBase<AirportAirline>, IAirportAirline
{
    public AirportAirlineRepository(AppDbContext context)
        : base(context)
    {
    }
}
