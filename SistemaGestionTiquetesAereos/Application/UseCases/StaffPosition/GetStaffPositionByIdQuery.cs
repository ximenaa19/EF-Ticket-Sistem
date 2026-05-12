using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffPosition;

public sealed record GetStaffPositionByIdQuery(Guid Id) : IRequest<Domain.Entities.StaffPosition>;
