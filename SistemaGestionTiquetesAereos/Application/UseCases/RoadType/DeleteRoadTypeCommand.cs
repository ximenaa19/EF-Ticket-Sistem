using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RoadType;

public sealed record DeleteRoadTypeCommand(Guid Id) : IRequest;
