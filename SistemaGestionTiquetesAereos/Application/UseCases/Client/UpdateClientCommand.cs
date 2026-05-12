using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Client;

public sealed record UpdateClientCommand(Guid Id, Guid PersonId, bool IsActive) : IRequest;
