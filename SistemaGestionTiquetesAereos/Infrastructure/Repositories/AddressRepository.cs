using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class AddressRepository : RepositoryBase<Address>, IAddress
{
    public AddressRepository(AppDbContext context)
        : base(context)
    {
    }
}
