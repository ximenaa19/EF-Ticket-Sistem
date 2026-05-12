using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RoadType;

public sealed record GetRoadTypeByIdQuery(Guid Id) : IRequest<Domain.Entities.RoadType>;
