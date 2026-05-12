using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckInStatus;

public sealed record CreateCheckInStatusCommand(string Name) : IRequest<Guid>;
