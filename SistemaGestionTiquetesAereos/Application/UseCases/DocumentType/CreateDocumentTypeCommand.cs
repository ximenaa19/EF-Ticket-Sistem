using MediatR;

namespace AirlineTicketSystem.Application.UseCases.DocumentType;

public sealed record CreateDocumentTypeCommand(string Name) : IRequest<Guid>;
