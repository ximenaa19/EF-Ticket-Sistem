using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class ReservationStatusTransitionRepository : RepositoryBase<ReservationStatusTransition>, IReservationStatusTransition
{
    public ReservationStatusTransitionRepository(AppDbContext context)
        : base(context)
    {
    }
}
