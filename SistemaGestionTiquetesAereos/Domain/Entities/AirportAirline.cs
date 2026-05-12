using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class AirportAirline : BaseEntity
{
    private AirportAirline()
    {

    }

    public AirportAirline(Guid airportId, Guid airlineId)
    {
        Validate(airportId, airlineId);

        AirportId = airportId;
        AirlineId = airlineId;
        IsActive = true;
    }

    public Guid AirportId { get; private set; }
    public Guid AirlineId { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid airportId, Guid airlineId, bool isActive)
    {
        Validate(airportId, airlineId);

        AirportId = airportId;
        AirlineId = airlineId;
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

    private static void Validate(Guid airportId, Guid airlineId)
    {
        if (airportId == Guid.Empty)
        {
            throw new InvalidDomainStateException("AirportId is required.");
        }

        if (airlineId == Guid.Empty)
        {
            throw new InvalidDomainStateException("AirlineId is required.");
        }
    }
}
