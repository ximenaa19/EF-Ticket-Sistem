using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Region;

public sealed record UpdateRegionCommand(Guid Id, string Name,
    Guid CountryId, bool IsActive) : IRequest;
