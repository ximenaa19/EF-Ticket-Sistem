using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airline;

public sealed record GetAirlineByIdQuery(Guid Id) : IRequest<Domain.Entities.Airline>;
