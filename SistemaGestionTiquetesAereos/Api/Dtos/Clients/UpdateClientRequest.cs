namespace AirlineTicketSystem.Api.Dtos.Clients;

public sealed record UpdateClientRequest(
    Guid PersonId,
    bool IsActive);
