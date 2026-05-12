using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PhoneCode;

public sealed record CreatePhoneCodeCommand(Guid CountryId,
    string Code) : IRequest<Guid>;
