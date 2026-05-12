using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethod;

public sealed record UpdatePaymentMethodCommand(Guid Id, Guid ClientId,
    Guid PaymentMethodTypeId,
    Guid? CardIssuerId,
    Guid? CardTypeId,
    string? MaskedNumber, bool IsActive) : IRequest;
