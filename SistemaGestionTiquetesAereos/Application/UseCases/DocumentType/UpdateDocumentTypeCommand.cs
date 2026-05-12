using MediatR;

namespace AirlineTicketSystem.Application.UseCases.DocumentType;

public sealed record UpdateDocumentTypeCommand(Guid Id, string Name, bool IsActive) : IRequest;
