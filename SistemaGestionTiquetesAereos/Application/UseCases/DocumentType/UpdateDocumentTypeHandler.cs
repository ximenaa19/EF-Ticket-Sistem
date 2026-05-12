using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.DocumentType;

public sealed class UpdateDocumentTypeHandler : IRequestHandler<UpdateDocumentTypeCommand>
{
    private readonly IDocumentType _documentTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDocumentTypeHandler(IDocumentType documentTypeRepository, IUnitOfWork unitOfWork)
    {
        _documentTypeRepository = documentTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateDocumentTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _documentTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.DocumentType), request.Id);

        if (await _documentTypeRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("DocumentType with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _documentTypeRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
