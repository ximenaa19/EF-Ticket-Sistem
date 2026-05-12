using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffAvailability;

public sealed record UpdateStaffAvailabilityCommand(Guid Id, Guid StaffId,
    Guid AvailabilityStatusId,
    DateTime AvailableFrom,
    DateTime AvailableTo, bool IsActive) : IRequest;
