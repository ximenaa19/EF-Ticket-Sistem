using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentStatus;

public sealed record CreatePaymentStatusCommand(string Name) : IRequest<Guid>;
