using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Continent;

public sealed record CreateContinentCommand(string Name) : IRequest<Guid>;
