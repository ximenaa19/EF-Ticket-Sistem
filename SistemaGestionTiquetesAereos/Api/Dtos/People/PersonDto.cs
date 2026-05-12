namespace AirlineTicketSystem.Api.Dtos.People;

public sealed record PersonDto(
    Guid Id,
    string FirstName,
    string LastName,
    Guid DocumentTypeId,
    string DocumentNumber,
    DateTime? BirthDate,
    Guid? AddressId,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
