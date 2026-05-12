using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PhoneCode;

public sealed record DeletePhoneCodeCommand(Guid Id) : IRequest;
