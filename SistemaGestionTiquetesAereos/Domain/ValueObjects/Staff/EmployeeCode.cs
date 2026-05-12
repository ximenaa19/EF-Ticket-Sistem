using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Staff;

public sealed record EmployeeCode
{
    public string Value { get; }

    public EmployeeCode(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(EmployeeCode), 40, 2, true);
    }

    public override string ToString() => Value;
}
