using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class ReservationPassengerRepository : RepositoryBase<ReservationPassenger>, IReservationPassenger
{
    public ReservationPassengerRepository(AppDbContext context)
        : base(context)
    {
    }
}
