using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Passenger;

public sealed record UpdatePassengerCommand(Guid Id, Guid PersonId,
    Guid PassengerTypeId, bool IsActive) : IRequest;
