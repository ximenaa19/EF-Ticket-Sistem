namespace AirlineTicketSystem.Api.Dtos.PersonPhones;

public sealed record UpdatePersonPhoneRequest(
    Guid PersonId,
    Guid PhoneCodeId,
    string Number,
    bool IsPrimary,
    bool IsActive);
