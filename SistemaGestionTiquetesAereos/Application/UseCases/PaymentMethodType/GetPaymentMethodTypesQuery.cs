using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethodType;

public sealed record GetPaymentMethodTypesQuery : IRequest<IReadOnlyList<Domain.Entities.PaymentMethodType>>;
