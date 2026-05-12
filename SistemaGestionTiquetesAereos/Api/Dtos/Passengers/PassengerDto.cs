namespace AirlineTicketSystem.Api.Dtos.Passengers;

public sealed record PassengerDto(
    Guid Id,
    Guid PersonId,
    Guid PassengerTypeId,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
