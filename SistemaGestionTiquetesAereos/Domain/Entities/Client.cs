using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Client : BaseEntity
{
    private Client()
    {

    }

    public Client(Guid personId)
    {
        Validate(personId);

        PersonId = personId;
        IsActive = true;
    }

    public Guid PersonId { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid personId, bool isActive)
    {
        Validate(personId);

        PersonId = personId;
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

    private static void Validate(Guid personId)
    {
        if (personId == Guid.Empty)
        {
            throw new InvalidDomainStateException("PersonId is required.");
        }
    }
}
