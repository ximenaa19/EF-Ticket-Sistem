using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Flight;

public sealed record UpdateFlightCommand(Guid Id, string FlightCode,
    Guid AirlineId,
    Guid RouteId,
    Guid AircraftId,
    DateTime DepartureDate,
    DateTime EstimatedArrivalDate,
    int TotalCapacity,
    int AvailableSeats,
    Guid FlightStatusId, bool IsActive) : IRequest;
