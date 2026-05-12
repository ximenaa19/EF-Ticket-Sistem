using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Route : BaseEntity
{
    private Route()
    {

    }

    public Route(Guid originAirportId, Guid destinationAirportId, decimal distanceKm)
    {
        Validate(originAirportId, destinationAirportId, distanceKm);

        OriginAirportId = originAirportId;
        DestinationAirportId = destinationAirportId;
        DistanceKm = distanceKm;
        IsActive = true;
    }

    public Guid OriginAirportId { get; private set; }
    public Guid DestinationAirportId { get; private set; }
    public decimal DistanceKm { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid originAirportId, Guid destinationAirportId, decimal distanceKm, bool isActive)
    {
        Validate(originAirportId, destinationAirportId, distanceKm);

        OriginAirportId = originAirportId;
        DestinationAirportId = destinationAirportId;
        DistanceKm = distanceKm;
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

    private static void Validate(Guid originAirportId, Guid destinationAirportId, decimal distanceKm)
    {
        if (originAirportId == Guid.Empty)
        {
            throw new InvalidDomainStateException("OriginAirportId is required.");
        }

        if (destinationAirportId == Guid.Empty)
        {
            throw new InvalidDomainStateException("DestinationAirportId is required.");
        }

        if (distanceKm < 0)
        {
            throw new InvalidDomainStateException("DistanceKm cannot be negative.");
        }
    }
}
