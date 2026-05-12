using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PhoneCode;

public sealed record UpdatePhoneCodeCommand(Guid Id, Guid CountryId,
    string Code, bool IsActive) : IRequest;
