using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Region;

public sealed record GetRegionsQuery : IRequest<IReadOnlyList<Domain.Entities.Region>>;
