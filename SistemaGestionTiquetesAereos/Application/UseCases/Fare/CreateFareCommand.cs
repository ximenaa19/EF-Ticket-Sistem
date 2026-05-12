using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Fare;

public sealed record CreateFareCommand(Guid FlightId,
    Guid PassengerTypeId,
    Guid CabinTypeId,
    decimal Amount,
    string Currency) : IRequest<Guid>;
