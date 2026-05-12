using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffPosition;

public sealed record GetStaffPositionsQuery : IRequest<IReadOnlyList<Domain.Entities.StaffPosition>>;
