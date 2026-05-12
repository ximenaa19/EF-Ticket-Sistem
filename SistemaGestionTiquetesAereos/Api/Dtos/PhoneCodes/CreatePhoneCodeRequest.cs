namespace AirlineTicketSystem.Api.Dtos.PhoneCodes;

public sealed record CreatePhoneCodeRequest(
    Guid CountryId,
    string Code);
