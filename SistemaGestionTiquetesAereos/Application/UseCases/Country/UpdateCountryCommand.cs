using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Country;

public sealed record UpdateCountryCommand(Guid Id, string Name,
    string IsoCode,
    Guid ContinentId, bool IsActive) : IRequest;
