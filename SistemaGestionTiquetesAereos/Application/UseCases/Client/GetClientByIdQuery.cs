using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Client;

public sealed record GetClientByIdQuery(Guid Id) : IRequest<Domain.Entities.Client>;
