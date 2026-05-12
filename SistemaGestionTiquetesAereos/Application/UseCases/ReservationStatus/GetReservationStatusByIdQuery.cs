using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatus;

public sealed record GetReservationStatusByIdQuery(Guid Id) : IRequest<Domain.Entities.ReservationStatus>;
