using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckIn;

public sealed record UpdateCheckInCommand(Guid Id, Guid TicketId,
    Guid CheckInStatusId,
    Guid? SeatId,
    DateTime CheckedInAt, bool IsActive) : IRequest;
