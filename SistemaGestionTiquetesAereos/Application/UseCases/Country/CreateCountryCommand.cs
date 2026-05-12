using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Country;

public sealed record CreateCountryCommand(string Name,
    string IsoCode,
    Guid ContinentId) : IRequest<Guid>;
