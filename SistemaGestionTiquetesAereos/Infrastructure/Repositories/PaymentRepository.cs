using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class PaymentRepository : RepositoryBase<Payment>, IPayment
{
    public PaymentRepository(AppDbContext context)
        : base(context)
    {
    }
}
