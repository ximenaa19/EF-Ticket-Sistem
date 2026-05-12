namespace AirlineTicketSystem.Api.Dtos.Addresses;

public sealed record AddressDto(
    Guid Id,
    Guid RoadTypeId,
    Guid CityId,
    string Street,
    string Number,
    string? AdditionalInfo,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
