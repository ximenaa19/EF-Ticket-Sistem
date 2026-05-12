using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatusTransition;

public sealed record GetReservationStatusTransitionByIdQuery(Guid Id) : IRequest<Domain.Entities.ReservationStatusTransition>;
