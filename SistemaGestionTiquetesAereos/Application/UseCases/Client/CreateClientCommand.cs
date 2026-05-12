using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Client;

public sealed record CreateClientCommand(Guid PersonId) : IRequest<Guid>;
