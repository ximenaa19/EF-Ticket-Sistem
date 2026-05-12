using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatusTransition;

public sealed record GetReservationStatusTransitionsQuery : IRequest<IReadOnlyList<Domain.Entities.ReservationStatusTransition>>;
