using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Passenger;

public sealed record GetPassengersQuery : IRequest<IReadOnlyList<Domain.Entities.Passenger>>;
