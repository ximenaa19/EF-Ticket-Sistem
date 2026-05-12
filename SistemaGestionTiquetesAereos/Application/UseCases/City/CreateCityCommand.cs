using MediatR;

namespace AirlineTicketSystem.Application.UseCases.City;

public sealed record CreateCityCommand(string Name,
    Guid RegionId) : IRequest<Guid>;
