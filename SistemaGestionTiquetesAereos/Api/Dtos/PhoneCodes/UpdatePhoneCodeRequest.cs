namespace AirlineTicketSystem.Api.Dtos.PhoneCodes;

public sealed record UpdatePhoneCodeRequest(
    Guid CountryId,
    string Code,
    bool IsActive);
