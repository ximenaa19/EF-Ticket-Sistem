using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Person;

public sealed record UpdatePersonCommand(Guid Id, string FirstName,
    string LastName,
    Guid DocumentTypeId,
    string DocumentNumber,
    DateTime? BirthDate,
    Guid? AddressId, bool IsActive) : IRequest;
