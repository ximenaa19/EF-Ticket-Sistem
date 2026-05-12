using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffAvailability;

public sealed record CreateStaffAvailabilityCommand(Guid StaffId,
    Guid AvailabilityStatusId,
    DateTime AvailableFrom,
    DateTime AvailableTo) : IRequest<Guid>;
