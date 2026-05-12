using MediatR;

namespace AirlineTicketSystem.Application.UseCases.EmailDomain;

public sealed record CreateEmailDomainCommand(string Name) : IRequest<Guid>;
