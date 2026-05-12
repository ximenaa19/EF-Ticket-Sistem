namespace AirlineTicketSystem.Api.Dtos.Airlines;

public sealed record UpdateAirlineRequest(string Name, string IataCode, bool IsActive);
