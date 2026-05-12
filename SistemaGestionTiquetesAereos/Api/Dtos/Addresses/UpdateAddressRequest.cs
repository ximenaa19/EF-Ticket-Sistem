namespace AirlineTicketSystem.Api.Dtos.Addresses;

public sealed record UpdateAddressRequest(
    Guid RoadTypeId,
    Guid CityId,
    string Street,
    string Number,
    string? AdditionalInfo,
    bool IsActive);
