using MediatR;

namespace AirlineTicketSystem.Application.UseCases.DocumentType;

public sealed record GetDocumentTypeByIdQuery(Guid Id) : IRequest<Domain.Entities.DocumentType>;
