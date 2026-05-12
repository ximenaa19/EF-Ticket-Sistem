using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonPhone;

public sealed record CreatePersonPhoneCommand(Guid PersonId,
    Guid PhoneCodeId,
    string Number,
    bool IsPrimary) : IRequest<Guid>;
