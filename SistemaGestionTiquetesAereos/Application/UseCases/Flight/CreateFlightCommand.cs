using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Flight;

public sealed record CreateFlightCommand(string FlightCode,
    Guid AirlineId,
    Guid RouteId,
    Guid AircraftId,
    DateTime DepartureDate,
    DateTime EstimatedArrivalDate,
    int TotalCapacity,
    int AvailableSeats,
    Guid FlightStatusId) : IRequest<Guid>;
