namespace AirlineTicketSystem.Api.Dtos.PersonPhones;

public sealed record PersonPhoneDto(
    Guid Id,
    Guid PersonId,
    Guid PhoneCodeId,
    string Number,
    bool IsPrimary,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
