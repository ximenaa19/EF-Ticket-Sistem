using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AvailabilityStatus;

public sealed record DeleteAvailabilityStatusCommand(Guid Id) : IRequest;
