using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airline;

public sealed record CreateAirlineCommand(string Name, string IataCode) : IRequest<Guid>;
