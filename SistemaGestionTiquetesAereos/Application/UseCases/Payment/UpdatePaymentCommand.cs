using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Payment;

public sealed record UpdatePaymentCommand(Guid Id, Guid ReservationId,
    Guid PaymentMethodId,
    Guid PaymentStatusId,
    decimal Amount,
    string Currency,
    DateTime? PaidAt, bool IsActive) : IRequest;
