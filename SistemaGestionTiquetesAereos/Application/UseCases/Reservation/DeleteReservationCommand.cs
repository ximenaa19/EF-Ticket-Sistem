using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Reservation;

public sealed record DeleteReservationCommand(Guid Id) : IRequest;
