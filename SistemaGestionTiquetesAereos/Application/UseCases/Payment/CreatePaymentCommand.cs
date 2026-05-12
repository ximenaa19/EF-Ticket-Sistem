using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Payment;

public sealed record CreatePaymentCommand(Guid ReservationId,
    Guid PaymentMethodId,
    Guid PaymentStatusId,
    decimal Amount,
    string Currency,
    DateTime? PaidAt) : IRequest<Guid>;
