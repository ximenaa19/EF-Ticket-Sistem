namespace AirlineTicketSystem.Api.Dtos.Seasons;

public sealed record UpdateSeasonRequest(
    string Name,
    bool IsActive);
