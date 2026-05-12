using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Fare : BaseEntity
{
    private Fare()
    {
        Currency = string.Empty;
    }

    public Fare(Guid flightId, Guid passengerTypeId, Guid cabinTypeId, decimal amount, string currency)
    {
        Validate(flightId, passengerTypeId, cabinTypeId, amount, currency);

        FlightId = flightId;
        PassengerTypeId = passengerTypeId;
        CabinTypeId = cabinTypeId;
        Amount = amount;
        Currency = currency.Trim().ToUpperInvariant();
        IsActive = true;
    }

    public Guid FlightId { get; private set; }
    public Guid PassengerTypeId { get; private set; }
    public Guid CabinTypeId { get; private set; }
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid flightId, Guid passengerTypeId, Guid cabinTypeId, decimal amount, string currency, bool isActive)
    {
        Validate(flightId, passengerTypeId, cabinTypeId, amount, currency);

        FlightId = flightId;
        PassengerTypeId = passengerTypeId;
        CabinTypeId = cabinTypeId;
        Amount = amount;
        Currency = currency.Trim().ToUpperInvariant();
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

    private static void Validate(Guid flightId, Guid passengerTypeId, Guid cabinTypeId, decimal amount, string currency)
    {
        if (flightId == Guid.Empty)
        {
            throw new InvalidDomainStateException("FlightId is required.");
        }

        if (passengerTypeId == Guid.Empty)
        {
            throw new InvalidDomainStateException("PassengerTypeId is required.");
        }

        if (cabinTypeId == Guid.Empty)
        {
            throw new InvalidDomainStateException("CabinTypeId is required.");
        }

        if (amount < 0)
        {
            throw new InvalidDomainStateException("Amount cannot be negative.");
        }

        if (string.IsNullOrWhiteSpace(currency))
        {
            throw new InvalidDomainStateException("Currency is required.");
        }
        if (currency.Trim().Length > 3)
        {
            throw new InvalidDomainStateException("Currency cannot exceed 3 characters.");
        }
    }
}
