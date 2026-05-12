using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonPhone;

public sealed record DeletePersonPhoneCommand(Guid Id) : IRequest;
