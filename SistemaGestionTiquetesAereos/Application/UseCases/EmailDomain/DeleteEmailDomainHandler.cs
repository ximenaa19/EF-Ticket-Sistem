using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.EmailDomain;

public sealed class DeleteEmailDomainHandler : IRequestHandler<DeleteEmailDomainCommand>
{
    private readonly IEmailDomain _emailDomainRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmailDomainHandler(IEmailDomain emailDomainRepository, IUnitOfWork unitOfWork)
    {
        _emailDomainRepository = emailDomainRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteEmailDomainCommand request, CancellationToken cancellationToken)
    {
        var entity = await _emailDomainRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.EmailDomain), request.Id);

        _emailDomainRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
