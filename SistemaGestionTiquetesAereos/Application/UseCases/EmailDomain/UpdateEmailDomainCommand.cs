using MediatR;

namespace AirlineTicketSystem.Application.UseCases.EmailDomain;

public sealed record UpdateEmailDomainCommand(Guid Id, string Name, bool IsActive) : IRequest;
