using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Reservation;

public sealed record GetReservationsQuery : IRequest<IReadOnlyList<Domain.Entities.Reservation>>;
