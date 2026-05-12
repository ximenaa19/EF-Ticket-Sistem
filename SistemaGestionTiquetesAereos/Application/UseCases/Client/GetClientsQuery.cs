using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Client;

public sealed record GetClientsQuery : IRequest<IReadOnlyList<Domain.Entities.Client>>;
