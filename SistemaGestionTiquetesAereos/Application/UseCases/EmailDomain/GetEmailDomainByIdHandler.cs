using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.EmailDomain;

public sealed class GetEmailDomainByIdHandler : IRequestHandler<GetEmailDomainByIdQuery, Domain.Entities.EmailDomain>
{
    private readonly IEmailDomain _emailDomainRepository;

    public GetEmailDomainByIdHandler(IEmailDomain emailDomainRepository)
    {
        _emailDomainRepository = emailDomainRepository;
    }

    public async Task<Domain.Entities.EmailDomain> Handle(GetEmailDomainByIdQuery request, CancellationToken cancellationToken)
    {
        return await _emailDomainRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.EmailDomain), request.Id);
    }
}
