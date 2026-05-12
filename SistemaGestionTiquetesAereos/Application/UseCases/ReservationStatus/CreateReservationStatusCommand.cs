using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatus;

public sealed record CreateReservationStatusCommand(string Name) : IRequest<Guid>;
