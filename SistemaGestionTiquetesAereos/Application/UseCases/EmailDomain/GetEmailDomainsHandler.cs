using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.EmailDomain;

public sealed class GetEmailDomainsHandler : IRequestHandler<GetEmailDomainsQuery, IReadOnlyList<Domain.Entities.EmailDomain>>
{
    private readonly IEmailDomain _emailDomainRepository;

    public GetEmailDomainsHandler(IEmailDomain emailDomainRepository)
    {
        _emailDomainRepository = emailDomainRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.EmailDomain>> Handle(GetEmailDomainsQuery request, CancellationToken cancellationToken)
    {
        return _emailDomainRepository.GetAllAsync(cancellationToken);
    }
}
