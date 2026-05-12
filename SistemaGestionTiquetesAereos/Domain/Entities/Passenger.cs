using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Passenger : BaseEntity
{
    private Passenger()
    {

    }

    public Passenger(Guid personId, Guid passengerTypeId)
    {
        Validate(personId, passengerTypeId);

        PersonId = personId;
        PassengerTypeId = passengerTypeId;
        IsActive = true;
    }

    public Guid PersonId { get; private set; }
    public Guid PassengerTypeId { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid personId, Guid passengerTypeId, bool isActive)
    {
        Validate(personId, passengerTypeId);

        PersonId = personId;
        PassengerTypeId = passengerTypeId;
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

    private static void Validate(Guid personId, Guid passengerTypeId)
    {
        if (personId == Guid.Empty)
        {
            throw new InvalidDomainStateException("PersonId is required.");
        }

        if (passengerTypeId == Guid.Empty)
        {
            throw new InvalidDomainStateException("PassengerTypeId is required.");
        }
    }
}
