using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatusTransition;

public sealed record DeleteReservationStatusTransitionCommand(Guid Id) : IRequest;
