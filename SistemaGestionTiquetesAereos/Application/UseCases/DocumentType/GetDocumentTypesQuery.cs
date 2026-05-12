using MediatR;

namespace AirlineTicketSystem.Application.UseCases.DocumentType;

public sealed record GetDocumentTypesQuery : IRequest<IReadOnlyList<Domain.Entities.DocumentType>>;
