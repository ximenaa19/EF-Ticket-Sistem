using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckIn;

public sealed record GetCheckInsQuery : IRequest<IReadOnlyList<Domain.Entities.CheckIn>>;
