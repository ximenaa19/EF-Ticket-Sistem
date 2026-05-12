using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airport;

public sealed record UpdateAirportCommand(Guid Id, string Name,
    string IataCode,
    string IcaoCode,
    Guid CityId, bool IsActive) : IRequest;
