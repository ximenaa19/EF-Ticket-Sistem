using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentStatus;

public sealed record UpdatePaymentStatusCommand(Guid Id, string Name, bool IsActive) : IRequest;
