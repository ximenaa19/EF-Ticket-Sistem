using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AvailabilityStatus;

public sealed record CreateAvailabilityStatusCommand(string Name) : IRequest<Guid>;
