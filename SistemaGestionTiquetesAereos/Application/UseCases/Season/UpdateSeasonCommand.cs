using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Season;

public sealed record UpdateSeasonCommand(Guid Id, string Name, bool IsActive) : IRequest;
