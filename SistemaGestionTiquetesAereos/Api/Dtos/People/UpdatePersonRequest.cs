namespace AirlineTicketSystem.Api.Dtos.People;

public sealed record UpdatePersonRequest(
    string FirstName,
    string LastName,
    Guid DocumentTypeId,
    string DocumentNumber,
    DateTime? BirthDate,
    Guid? AddressId,
    bool IsActive);
