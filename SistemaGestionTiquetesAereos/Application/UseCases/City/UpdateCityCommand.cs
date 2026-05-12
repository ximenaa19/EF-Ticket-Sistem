using MediatR;

namespace AirlineTicketSystem.Application.UseCases.City;

public sealed record UpdateCityCommand(Guid Id, string Name,
    Guid RegionId, bool IsActive) : IRequest;
