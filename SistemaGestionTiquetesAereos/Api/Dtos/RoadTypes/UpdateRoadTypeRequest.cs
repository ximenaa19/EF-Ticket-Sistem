namespace AirlineTicketSystem.Api.Dtos.RoadTypes;

public sealed record UpdateRoadTypeRequest(
    string Name,
    bool IsActive);
