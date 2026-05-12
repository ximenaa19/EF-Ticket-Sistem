namespace AirlineTicketSystem.Api.Dtos.StaffPositions;

public sealed record UpdateStaffPositionRequest(
    string Name,
    bool IsActive);
