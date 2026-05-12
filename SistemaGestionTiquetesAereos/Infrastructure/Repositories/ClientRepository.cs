using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class ClientRepository : RepositoryBase<Client>, IClient
{
    public ClientRepository(AppDbContext context)
        : base(context)
    {
    }
}
