using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RoadType;

public sealed record UpdateRoadTypeCommand(Guid Id, string Name, bool IsActive) : IRequest;
