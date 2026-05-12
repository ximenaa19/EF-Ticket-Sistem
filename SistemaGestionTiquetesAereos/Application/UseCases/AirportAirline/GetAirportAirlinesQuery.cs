using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AirportAirline;

public sealed record GetAirportAirlinesQuery : IRequest<IReadOnlyList<Domain.Entities.AirportAirline>>;
