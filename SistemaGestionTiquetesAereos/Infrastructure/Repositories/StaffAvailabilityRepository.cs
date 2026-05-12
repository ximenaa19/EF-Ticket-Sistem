using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class StaffAvailabilityRepository : RepositoryBase<StaffAvailability>, IStaffAvailability
{
    public StaffAvailabilityRepository(AppDbContext context)
        : base(context)
    {
    }
}
