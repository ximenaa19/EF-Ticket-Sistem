using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PaymentStatus;

public sealed record GetPaymentStatusesQuery : IRequest<IReadOnlyList<Domain.Entities.PaymentStatus>>;
