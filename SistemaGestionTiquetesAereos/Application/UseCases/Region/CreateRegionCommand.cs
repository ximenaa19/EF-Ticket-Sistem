using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Region;

public sealed record CreateRegionCommand(string Name,
    Guid CountryId) : IRequest<Guid>;
