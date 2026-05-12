using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinConfiguration;

public sealed record GetCabinConfigurationsQuery : IRequest<IReadOnlyList<Domain.Entities.CabinConfiguration>>;
