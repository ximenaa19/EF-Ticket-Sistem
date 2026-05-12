using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.DocumentType;

public sealed class GetDocumentTypesHandler : IRequestHandler<GetDocumentTypesQuery, IReadOnlyList<Domain.Entities.DocumentType>>
{
    private readonly IDocumentType _documentTypeRepository;

    public GetDocumentTypesHandler(IDocumentType documentTypeRepository)
    {
        _documentTypeRepository = documentTypeRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.DocumentType>> Handle(GetDocumentTypesQuery request, CancellationToken cancellationToken)
    {
        return _documentTypeRepository.GetAllAsync(cancellationToken);
    }
}
