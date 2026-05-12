using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Aircraft;

public sealed record GetAircraftQuery : IRequest<IReadOnlyList<Domain.Entities.Aircraft>>;
