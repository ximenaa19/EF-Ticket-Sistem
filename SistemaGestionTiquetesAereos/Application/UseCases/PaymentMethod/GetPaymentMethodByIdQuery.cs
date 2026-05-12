using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethod;

public sealed record GetPaymentMethodByIdQuery(Guid Id) : IRequest<Domain.Entities.PaymentMethod>;
