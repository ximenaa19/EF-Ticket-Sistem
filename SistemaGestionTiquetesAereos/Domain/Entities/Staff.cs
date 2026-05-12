using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Staff : BaseEntity
{
    private Staff()
    {
        EmployeeCode = string.Empty;
    }

    public Staff(Guid personId, Guid staffPositionId, string employeeCode)
    {
        Validate(personId, staffPositionId, employeeCode);

        PersonId = personId;
        StaffPositionId = staffPositionId;
        EmployeeCode = employeeCode.Trim().ToUpperInvariant();
        IsActive = true;
    }

    public Guid PersonId { get; private set; }
    public Guid StaffPositionId { get; private set; }
    public string EmployeeCode { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid personId, Guid staffPositionId, string employeeCode, bool isActive)
    {
        Validate(personId, staffPositionId, employeeCode);

        PersonId = personId;
        StaffPositionId = staffPositionId;
        EmployeeCode = employeeCode.Trim().ToUpperInvariant();
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

    private static void Validate(Guid personId, Guid staffPositionId, string employeeCode)
    {
        if (personId == Guid.Empty)
        {
            throw new InvalidDomainStateException("PersonId is required.");
        }

        if (staffPositionId == Guid.Empty)
        {
            throw new InvalidDomainStateException("StaffPositionId is required.");
        }

        if (string.IsNullOrWhiteSpace(employeeCode))
        {
            throw new InvalidDomainStateException("EmployeeCode is required.");
        }
        if (employeeCode.Trim().Length > 40)
        {
            throw new InvalidDomainStateException("EmployeeCode cannot exceed 40 characters.");
        }
    }
}
