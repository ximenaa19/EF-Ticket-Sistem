using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffAvailability;

public sealed record DeleteStaffAvailabilityCommand(Guid Id) : IRequest;
