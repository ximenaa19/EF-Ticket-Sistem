using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.EmailDomain;

public sealed class CreateEmailDomainHandler : IRequestHandler<CreateEmailDomainCommand, Guid>
{
    private readonly IEmailDomain _emailDomainRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmailDomainHandler(IEmailDomain emailDomainRepository, IUnitOfWork unitOfWork)
    {
        _emailDomainRepository = emailDomainRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateEmailDomainCommand request, CancellationToken cancellationToken)
    {
        if (await _emailDomainRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("EmailDomain with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.EmailDomain(request.Name);

        await _emailDomainRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
