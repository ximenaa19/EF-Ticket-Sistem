using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonPhone;

public sealed record UpdatePersonPhoneCommand(Guid Id, Guid PersonId,
    Guid PhoneCodeId,
    string Number,
    bool IsPrimary, bool IsActive) : IRequest;
