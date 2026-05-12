using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinType;

public sealed record GetCabinTypesQuery : IRequest<IReadOnlyList<Domain.Entities.CabinType>>;
