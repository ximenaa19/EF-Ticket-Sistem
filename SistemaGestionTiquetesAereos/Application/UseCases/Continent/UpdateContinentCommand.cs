using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Continent;

public sealed record UpdateContinentCommand(Guid Id, string Name, bool IsActive) : IRequest;
