using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethod;

public sealed record DeletePaymentMethodCommand(Guid Id) : IRequest;
