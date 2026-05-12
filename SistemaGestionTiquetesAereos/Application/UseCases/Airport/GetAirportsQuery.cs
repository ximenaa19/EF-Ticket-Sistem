using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airport;

public sealed record GetAirportsQuery : IRequest<IReadOnlyList<Domain.Entities.Airport>>;
