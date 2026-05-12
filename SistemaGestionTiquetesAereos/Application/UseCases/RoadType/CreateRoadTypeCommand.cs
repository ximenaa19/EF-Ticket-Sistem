using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RoadType;

public sealed record CreateRoadTypeCommand(string Name) : IRequest<Guid>;
