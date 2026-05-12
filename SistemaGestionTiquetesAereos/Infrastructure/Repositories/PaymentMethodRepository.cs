using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Repositories;

public sealed class PaymentMethodRepository : RepositoryBase<PaymentMethod>, IPaymentMethod
{
    public PaymentMethodRepository(AppDbContext context)
        : base(context)
    {
    }
}
