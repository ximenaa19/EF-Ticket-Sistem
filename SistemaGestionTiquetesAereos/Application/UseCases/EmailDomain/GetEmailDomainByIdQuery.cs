using MediatR;

namespace AirlineTicketSystem.Application.UseCases.EmailDomain;

public sealed record GetEmailDomainByIdQuery(Guid Id) : IRequest<Domain.Entities.EmailDomain>;
