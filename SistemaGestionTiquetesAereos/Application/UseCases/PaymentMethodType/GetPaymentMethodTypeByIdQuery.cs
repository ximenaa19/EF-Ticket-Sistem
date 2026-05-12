using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethodType;

public sealed record GetPaymentMethodTypeByIdQuery(Guid Id) : IRequest<Domain.Entities.PaymentMethodType>;
