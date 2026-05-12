using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethodType;

public sealed record UpdatePaymentMethodTypeCommand(Guid Id, string Name, bool IsActive) : IRequest;
