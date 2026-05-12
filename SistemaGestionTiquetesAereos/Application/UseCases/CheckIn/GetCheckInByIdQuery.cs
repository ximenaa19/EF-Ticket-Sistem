using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckIn;

public sealed record GetCheckInByIdQuery(Guid Id) : IRequest<Domain.Entities.CheckIn>;
