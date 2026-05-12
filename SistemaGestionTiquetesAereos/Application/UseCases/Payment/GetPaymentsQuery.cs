using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Payment;

public sealed record GetPaymentsQuery : IRequest<IReadOnlyList<Domain.Entities.Payment>>;
