using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckInStatus;

public sealed record GetCheckInStatusesQuery : IRequest<IReadOnlyList<Domain.Entities.CheckInStatus>>;
