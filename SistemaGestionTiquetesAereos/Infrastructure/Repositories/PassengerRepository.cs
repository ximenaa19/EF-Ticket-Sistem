using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class PassengerRepository : RepositoryBase<Passenger>, IPassenger
{
    public PassengerRepository(AppDbContext context)
        : base(context)
    {
    }
}
