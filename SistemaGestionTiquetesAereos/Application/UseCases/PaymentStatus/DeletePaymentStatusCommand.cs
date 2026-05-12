using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentStatus;

public sealed record DeletePaymentStatusCommand(Guid Id) : IRequest;
