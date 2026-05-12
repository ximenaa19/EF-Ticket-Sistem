using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airport;

public sealed record GetAirportByIdQuery(Guid Id) : IRequest<Domain.Entities.Airport>;
