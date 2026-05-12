namespace AirlineTicketSystem.Api.Dtos.PersonPhones;

public sealed record CreatePersonPhoneRequest(
    Guid PersonId,
    Guid PhoneCodeId,
    string Number,
    bool IsPrimary);
