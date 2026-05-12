using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class RouteStopRepository : RepositoryBase<RouteStop>, IRouteStop
{
    public RouteStopRepository(AppDbContext context)
        : base(context)
    {
    }
}
