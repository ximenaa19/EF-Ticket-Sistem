using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class RouteStop : BaseEntity
{
    private RouteStop()
    {

    }

    public RouteStop(Guid routeId, Guid airportId, int stopOrder)
    {
        Validate(routeId, airportId, stopOrder);

        RouteId = routeId;
        AirportId = airportId;
        StopOrder = stopOrder;
        IsActive = true;
    }

    public Guid RouteId { get; private set; }
    public Guid AirportId { get; private set; }
    public int StopOrder { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid routeId, Guid airportId, int stopOrder, bool isActive)
    {
        Validate(routeId, airportId, stopOrder);

        RouteId = routeId;
        AirportId = airportId;
        StopOrder = stopOrder;
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

    private static void Validate(Guid routeId, Guid airportId, int stopOrder)
    {
        if (routeId == Guid.Empty)
        {
            throw new InvalidDomainStateException("RouteId is required.");
        }

        if (airportId == Guid.Empty)
        {
            throw new InvalidDomainStateException("AirportId is required.");
        }

        if (stopOrder < 0)
        {
            throw new InvalidDomainStateException("StopOrder cannot be negative.");
        }
    }
}
