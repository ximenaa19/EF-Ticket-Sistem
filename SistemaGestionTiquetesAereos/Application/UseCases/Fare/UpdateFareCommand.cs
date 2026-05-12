using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Fare;

public sealed record UpdateFareCommand(Guid Id, Guid FlightId,
    Guid PassengerTypeId,
    Guid CabinTypeId,
    decimal Amount,
    string Currency, bool IsActive) : IRequest;
