using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Staff;

public sealed record GetStaffQuery : IRequest<IReadOnlyList<Domain.Entities.Staff>>;
