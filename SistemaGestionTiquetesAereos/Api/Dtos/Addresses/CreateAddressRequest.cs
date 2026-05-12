namespace AirlineTicketSystem.Api.Dtos.Addresses;

public sealed record CreateAddressRequest(
    Guid RoadTypeId,
    Guid CityId,
    string Street,
    string Number,
    string? AdditionalInfo);
