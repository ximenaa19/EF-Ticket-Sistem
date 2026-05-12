using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AirportAirline;

public sealed record GetAirportAirlineByIdQuery(Guid Id) : IRequest<Domain.Entities.AirportAirline>;
