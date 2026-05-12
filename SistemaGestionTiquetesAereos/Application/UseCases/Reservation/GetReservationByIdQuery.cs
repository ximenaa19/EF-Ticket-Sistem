using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Reservation;

public sealed record GetReservationByIdQuery(Guid Id) : IRequest<Domain.Entities.Reservation>;
