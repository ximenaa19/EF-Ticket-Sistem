using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class PersonEmailRepository : RepositoryBase<PersonEmail>, IPersonEmail
{
    public PersonEmailRepository(AppDbContext context)
        : base(context)
    {
    }
}
