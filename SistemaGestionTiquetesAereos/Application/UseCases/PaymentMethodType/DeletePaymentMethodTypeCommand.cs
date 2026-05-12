using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethodType;

public sealed record DeletePaymentMethodTypeCommand(Guid Id) : IRequest;
