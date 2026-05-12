using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AvailabilityStatus;

public sealed record GetAvailabilityStatusByIdQuery(Guid Id) : IRequest<Domain.Entities.AvailabilityStatus>;
