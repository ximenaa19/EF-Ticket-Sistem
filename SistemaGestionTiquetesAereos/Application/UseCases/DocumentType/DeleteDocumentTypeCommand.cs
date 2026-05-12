using MediatR;

namespace AirlineTicketSystem.Application.UseCases.DocumentType;

public sealed record DeleteDocumentTypeCommand(Guid Id) : IRequest;
