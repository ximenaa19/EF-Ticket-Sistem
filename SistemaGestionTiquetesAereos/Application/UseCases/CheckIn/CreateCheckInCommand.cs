using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckIn;

public sealed record CreateCheckInCommand(Guid TicketId,
    Guid CheckInStatusId,
    Guid? SeatId,
    DateTime CheckedInAt) : IRequest<Guid>;
