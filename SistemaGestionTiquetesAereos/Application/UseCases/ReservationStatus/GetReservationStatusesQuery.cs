using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatus;

public sealed record GetReservationStatusesQuery : IRequest<IReadOnlyList<Domain.Entities.ReservationStatus>>;
