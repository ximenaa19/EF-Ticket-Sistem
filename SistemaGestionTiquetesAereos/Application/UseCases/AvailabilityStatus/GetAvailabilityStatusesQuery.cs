using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AvailabilityStatus;

public sealed record GetAvailabilityStatusesQuery : IRequest<IReadOnlyList<Domain.Entities.AvailabilityStatus>>;
