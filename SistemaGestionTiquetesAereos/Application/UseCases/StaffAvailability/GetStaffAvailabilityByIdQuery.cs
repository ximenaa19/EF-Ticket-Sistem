using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffAvailability;

public sealed record GetStaffAvailabilityByIdQuery(Guid Id) : IRequest<Domain.Entities.StaffAvailability>;
