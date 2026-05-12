using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airline;

public sealed record UpdateAirlineCommand(Guid Id, string Name, string IataCode, bool IsActive) : IRequest;
