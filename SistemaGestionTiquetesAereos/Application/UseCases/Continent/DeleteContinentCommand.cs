using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Continent;

public sealed record DeleteContinentCommand(Guid Id) : IRequest;
