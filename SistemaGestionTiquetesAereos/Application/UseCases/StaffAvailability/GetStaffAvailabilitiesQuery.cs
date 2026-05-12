using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffAvailability;

public sealed record GetStaffAvailabilitiesQuery : IRequest<IReadOnlyList<Domain.Entities.StaffAvailability>>;
