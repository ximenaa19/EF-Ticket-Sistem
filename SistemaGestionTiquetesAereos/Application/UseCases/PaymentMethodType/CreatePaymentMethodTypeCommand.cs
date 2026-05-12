using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethodType;

public sealed record CreatePaymentMethodTypeCommand(string Name) : IRequest<Guid>;
