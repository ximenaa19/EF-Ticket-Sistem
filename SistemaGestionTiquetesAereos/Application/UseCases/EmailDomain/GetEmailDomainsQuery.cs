using MediatR;

namespace AirlineTicketSystem.Application.UseCases.EmailDomain;

public sealed record GetEmailDomainsQuery : IRequest<IReadOnlyList<Domain.Entities.EmailDomain>>;
