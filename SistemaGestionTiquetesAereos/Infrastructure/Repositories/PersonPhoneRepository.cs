using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class PersonPhoneRepository : RepositoryBase<PersonPhone>, IPersonPhone
{
    public PersonPhoneRepository(AppDbContext context)
        : base(context)
    {
    }
}
