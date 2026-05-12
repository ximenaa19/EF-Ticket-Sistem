namespace AirlineTicketSystem.Api.Dtos.Airlines;

public sealed record CreateAirlineRequest(string Name, string IataCode);
