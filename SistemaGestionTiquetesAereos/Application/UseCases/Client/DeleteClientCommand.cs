using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Client;

public sealed record DeleteClientCommand(Guid Id) : IRequest;
