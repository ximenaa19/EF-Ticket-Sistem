using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.DocumentType;

public sealed class CreateDocumentTypeHandler : IRequestHandler<CreateDocumentTypeCommand, Guid>
{
    private readonly IDocumentType _documentTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDocumentTypeHandler(IDocumentType documentTypeRepository, IUnitOfWork unitOfWork)
    {
        _documentTypeRepository = documentTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateDocumentTypeCommand request, CancellationToken cancellationToken)
    {
        if (await _documentTypeRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("DocumentType with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.DocumentType(request.Name);

        await _documentTypeRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
