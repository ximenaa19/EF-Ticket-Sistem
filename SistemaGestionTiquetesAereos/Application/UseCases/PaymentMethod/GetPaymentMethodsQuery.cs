using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethod;

public sealed record GetPaymentMethodsQuery : IRequest<IReadOnlyList<Domain.Entities.PaymentMethod>>;
