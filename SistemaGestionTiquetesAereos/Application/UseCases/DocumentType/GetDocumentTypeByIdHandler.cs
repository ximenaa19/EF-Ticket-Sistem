using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.DocumentType;

public sealed class GetDocumentTypeByIdHandler : IRequestHandler<GetDocumentTypeByIdQuery, Domain.Entities.DocumentType>
{
    private readonly IDocumentType _documentTypeRepository;

    public GetDocumentTypeByIdHandler(IDocumentType documentTypeRepository)
    {
        _documentTypeRepository = documentTypeRepository;
    }

    public async Task<Domain.Entities.DocumentType> Handle(GetDocumentTypeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _documentTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.DocumentType), request.Id);
    }
}
