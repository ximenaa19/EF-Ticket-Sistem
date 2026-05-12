namespace AirlineTicketSystem.Api.Dtos.PhoneCodes;

public sealed record PhoneCodeDto(
    Guid Id,
    Guid CountryId,
    string Code,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
