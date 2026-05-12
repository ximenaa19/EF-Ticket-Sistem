using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AvailabilityStatus;

public sealed record UpdateAvailabilityStatusCommand(Guid Id, string Name, bool IsActive) : IRequest;
