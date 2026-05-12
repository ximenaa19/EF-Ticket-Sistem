using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.EmailDomain;

public sealed class UpdateEmailDomainHandler : IRequestHandler<UpdateEmailDomainCommand>
{
    private readonly IEmailDomain _emailDomainRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmailDomainHandler(IEmailDomain emailDomainRepository, IUnitOfWork unitOfWork)
    {
        _emailDomainRepository = emailDomainRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateEmailDomainCommand request, CancellationToken cancellationToken)
    {
        var entity = await _emailDomainRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.EmailDomain), request.Id);

        if (await _emailDomainRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("EmailDomain with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _emailDomainRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
