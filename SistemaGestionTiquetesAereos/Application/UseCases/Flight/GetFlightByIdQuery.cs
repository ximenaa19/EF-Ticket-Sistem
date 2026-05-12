using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Flight;

public sealed record GetFlightByIdQuery(Guid Id) : IRequest<Domain.Entities.Flight>;
