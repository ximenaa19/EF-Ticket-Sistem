using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckInStatus;

public sealed record DeleteCheckInStatusCommand(Guid Id) : IRequest;
