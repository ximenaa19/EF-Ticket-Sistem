using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatus;

public sealed record DeleteReservationStatusCommand(Guid Id) : IRequest;
