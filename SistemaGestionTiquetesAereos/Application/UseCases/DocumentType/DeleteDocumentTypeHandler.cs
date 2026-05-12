using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.DocumentType;

public sealed class DeleteDocumentTypeHandler : IRequestHandler<DeleteDocumentTypeCommand>
{
    private readonly IDocumentType _documentTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDocumentTypeHandler(IDocumentType documentTypeRepository, IUnitOfWork unitOfWork)
    {
        _documentTypeRepository = documentTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteDocumentTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _documentTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.DocumentType), request.Id);

        _documentTypeRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
