namespace AirlineTicketSystem.Api.Dtos.People;

public sealed record CreatePersonRequest(
    string FirstName,
    string LastName,
    Guid DocumentTypeId,
    string DocumentNumber,
    DateTime? BirthDate,
    Guid? AddressId);
