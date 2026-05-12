using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Staff;

public sealed record GetStaffByIdQuery(Guid Id) : IRequest<Domain.Entities.Staff>;
