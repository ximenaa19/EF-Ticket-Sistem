using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Flight;

public sealed record GetFlightsQuery : IRequest<IReadOnlyList<Domain.Entities.Flight>>;
