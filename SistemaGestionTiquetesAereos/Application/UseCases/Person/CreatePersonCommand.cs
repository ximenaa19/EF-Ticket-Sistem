using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Person;

public sealed record CreatePersonCommand(string FirstName,
    string LastName,
    Guid DocumentTypeId,
    string DocumentNumber,
    DateTime? BirthDate,
    Guid? AddressId) : IRequest<Guid>;
