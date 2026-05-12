using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Season;

public sealed record GetSeasonByIdQuery(Guid Id) : IRequest<Domain.Entities.Season>;
