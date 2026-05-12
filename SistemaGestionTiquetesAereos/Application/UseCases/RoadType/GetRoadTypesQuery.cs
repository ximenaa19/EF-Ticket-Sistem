using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RoadType;

public sealed record GetRoadTypesQuery : IRequest<IReadOnlyList<Domain.Entities.RoadType>>;
