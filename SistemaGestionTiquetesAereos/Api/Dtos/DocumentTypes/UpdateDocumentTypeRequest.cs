namespace AirlineTicketSystem.Api.Dtos.DocumentTypes;

public sealed record UpdateDocumentTypeRequest(
    string Name,
    bool IsActive);
