using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PassengerType;

public sealed record GetPassengerTypesQuery : IRequest<IReadOnlyList<Domain.Entities.PassengerType>>;
