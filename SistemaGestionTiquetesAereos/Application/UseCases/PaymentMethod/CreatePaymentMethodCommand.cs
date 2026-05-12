using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethod;

public sealed record CreatePaymentMethodCommand(Guid ClientId,
    Guid PaymentMethodTypeId,
    Guid? CardIssuerId,
    Guid? CardTypeId,
    string? MaskedNumber) : IRequest<Guid>;
