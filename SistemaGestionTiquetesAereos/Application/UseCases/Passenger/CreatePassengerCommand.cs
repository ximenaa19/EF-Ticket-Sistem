using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Passenger;

public sealed record CreatePassengerCommand(Guid PersonId,
    Guid PassengerTypeId) : IRequest<Guid>;
