using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Payment;

public sealed record DeletePaymentCommand(Guid Id) : IRequest;
