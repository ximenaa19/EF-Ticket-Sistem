using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airport;

public sealed record CreateAirportCommand(string Name,
    string IataCode,
    string IcaoCode,
    Guid CityId) : IRequest<Guid>;
