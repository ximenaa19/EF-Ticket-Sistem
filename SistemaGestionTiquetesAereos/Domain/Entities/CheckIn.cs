using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class CheckIn : BaseEntity
{
    private CheckIn()
    {

    }

    public CheckIn(Guid ticketId, Guid checkInStatusId, Guid? seatId, DateTime checkedInAt)
    {
        Validate(ticketId, checkInStatusId, seatId, checkedInAt);

        TicketId = ticketId;
        CheckInStatusId = checkInStatusId;
        SeatId = seatId;
        CheckedInAt = checkedInAt;
        IsActive = true;
    }

    public Guid TicketId { get; private set; }
    public Guid CheckInStatusId { get; private set; }
    public Guid? SeatId { get; private set; }
    public DateTime CheckedInAt { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid ticketId, Guid checkInStatusId, Guid? seatId, DateTime checkedInAt, bool isActive)
    {
        Validate(ticketId, checkInStatusId, seatId, checkedInAt);

        TicketId = ticketId;
        CheckInStatusId = checkInStatusId;
        SeatId = seatId;
        CheckedInAt = checkedInAt;
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

    private static void Validate(Guid ticketId, Guid checkInStatusId, Guid? seatId, DateTime checkedInAt)
    {
        if (ticketId == Guid.Empty)
        {
            throw new InvalidDomainStateException("TicketId is required.");
        }

        if (checkInStatusId == Guid.Empty)
        {
            throw new InvalidDomainStateException("CheckInStatusId is required.");
        }
    }
}
