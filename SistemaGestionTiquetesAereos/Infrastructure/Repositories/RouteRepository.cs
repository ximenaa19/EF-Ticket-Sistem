using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class RouteRepository : RepositoryBase<Route>, IRoute
{
    public RouteRepository(AppDbContext context)
        : base(context)
    {
    }
}
