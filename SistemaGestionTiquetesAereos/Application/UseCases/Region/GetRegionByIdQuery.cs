using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Region;

public sealed record GetRegionByIdQuery(Guid Id) : IRequest<Domain.Entities.Region>;
