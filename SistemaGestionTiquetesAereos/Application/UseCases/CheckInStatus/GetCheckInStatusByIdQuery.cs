using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckInStatus;

public sealed record GetCheckInStatusByIdQuery(Guid Id) : IRequest<Domain.Entities.CheckInStatus>;
