using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Flight : BaseEntity
{
    private Flight()
    {
        FlightCode = string.Empty;
    }

    public Flight(string flightCode, Guid airlineId, Guid routeId, Guid aircraftId, DateTime departureDate, DateTime estimatedArrivalDate, int totalCapacity, int availableSeats, Guid flightStatusId)
    {
        Validate(flightCode, airlineId, routeId, aircraftId, departureDate, estimatedArrivalDate, totalCapacity, availableSeats, flightStatusId);

        FlightCode = flightCode.Trim().ToUpperInvariant();
        AirlineId = airlineId;
        RouteId = routeId;
        AircraftId = aircraftId;
        DepartureDate = departureDate;
        EstimatedArrivalDate = estimatedArrivalDate;
        TotalCapacity = totalCapacity;
        AvailableSeats = availableSeats;
        FlightStatusId = flightStatusId;
        IsActive = true;
    }

    public string FlightCode { get; private set; }
    public Guid AirlineId { get; private set; }
    public Guid RouteId { get; private set; }
    public Guid AircraftId { get; private set; }
    public DateTime DepartureDate { get; private set; }
    public DateTime EstimatedArrivalDate { get; private set; }
    public int TotalCapacity { get; private set; }
    public int AvailableSeats { get; private set; }
    public Guid FlightStatusId { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(string flightCode, Guid airlineId, Guid routeId, Guid aircraftId, DateTime departureDate, DateTime estimatedArrivalDate, int totalCapacity, int availableSeats, Guid flightStatusId, bool isActive)
    {
        Validate(flightCode, airlineId, routeId, aircraftId, departureDate, estimatedArrivalDate, totalCapacity, availableSeats, flightStatusId);

        FlightCode = flightCode.Trim().ToUpperInvariant();
        AirlineId = airlineId;
        RouteId = routeId;
        AircraftId = aircraftId;
        DepartureDate = departureDate;
        EstimatedArrivalDate = estimatedArrivalDate;
        TotalCapacity = totalCapacity;
        AvailableSeats = availableSeats;
        FlightStatusId = flightStatusId;
        IsActive = isActive;

        MarkAsUpdated();
    }

    public void Activate()
    {
        IsActive = true;
        MarkAsUpdated();
    }

    public void Deactivate()
    {
        IsActive = false;
        MarkAsUpdated();
    }

    private static void Validate(string flightCode, Guid airlineId, Guid routeId, Guid aircraftId, DateTime departureDate, DateTime estimatedArrivalDate, int totalCapacity, int availableSeats, Guid flightStatusId)
    {
        if (string.IsNullOrWhiteSpace(flightCode))
        {
            throw new InvalidDomainStateException("FlightCode is required.");
        }
        if (flightCode.Trim().Length > 20)
        {
            throw new InvalidDomainStateException("FlightCode cannot exceed 20 characters.");
        }

        if (airlineId == Guid.Empty)
        {
            throw new InvalidDomainStateException("AirlineId is required.");
        }

        if (routeId == Guid.Empty)
        {
            throw new InvalidDomainStateException("RouteId is required.");
        }

        if (aircraftId == Guid.Empty)
        {
            throw new InvalidDomainStateException("AircraftId is required.");
        }

        if (totalCapacity < 0)
        {
            throw new InvalidDomainStateException("TotalCapacity cannot be negative.");
        }

        if (availableSeats < 0)
        {
            throw new InvalidDomainStateException("AvailableSeats cannot be negative.");
        }

        if (flightStatusId == Guid.Empty)
        {
            throw new InvalidDomainStateException("FlightStatusId is required.");
        }
    }
}
