using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Aircraft;

public sealed record GetAircraftByIdQuery(Guid Id) : IRequest<Domain.Entities.Aircraft>;
