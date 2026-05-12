using MediatR;

namespace AirlineTicketSystem.Application.UseCases.EmailDomain;

public sealed record DeleteEmailDomainCommand(Guid Id) : IRequest;
