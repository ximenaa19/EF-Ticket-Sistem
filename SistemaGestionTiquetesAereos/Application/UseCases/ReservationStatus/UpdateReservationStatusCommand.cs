using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatus;

public sealed record UpdateReservationStatusCommand(Guid Id, string Name, bool IsActive) : IRequest;
