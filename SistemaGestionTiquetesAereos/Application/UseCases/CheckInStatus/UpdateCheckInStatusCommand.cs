using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckInStatus;

public sealed record UpdateCheckInStatusCommand(Guid Id, string Name, bool IsActive) : IRequest;
