using AirlineTicketSystem.Api.Dtos.Addresses;
using AirlineTicketSystem.Api.Dtos.Aircraft;
using AirlineTicketSystem.Api.Dtos.AircraftManufacturers;
using AirlineTicketSystem.Api.Dtos.AircraftModels;
using AirlineTicketSystem.Api.Dtos.Airlines;
using AirlineTicketSystem.Api.Dtos.AirportAirlines;
using AirlineTicketSystem.Api.Dtos.Airports;
using AirlineTicketSystem.Api.Dtos.AvailabilityStatuses;
using AirlineTicketSystem.Api.Dtos.CabinConfigurations;
using AirlineTicketSystem.Api.Dtos.CabinTypes;
using AirlineTicketSystem.Api.Dtos.CardIssuers;
using AirlineTicketSystem.Api.Dtos.CardTypes;
using AirlineTicketSystem.Api.Dtos.CheckIns;
using AirlineTicketSystem.Api.Dtos.CheckInStatuses;
using AirlineTicketSystem.Api.Dtos.Cities;
using AirlineTicketSystem.Api.Dtos.Clients;
using AirlineTicketSystem.Api.Dtos.Continents;
using AirlineTicketSystem.Api.Dtos.Countries;
using AirlineTicketSystem.Api.Dtos.DocumentTypes;
using AirlineTicketSystem.Api.Dtos.EmailDomains;
using AirlineTicketSystem.Api.Dtos.Fares;
using AirlineTicketSystem.Api.Dtos.FlightAssignments;
using AirlineTicketSystem.Api.Dtos.FlightRoles;
using AirlineTicketSystem.Api.Dtos.Flights;
using AirlineTicketSystem.Api.Dtos.FlightSeats;
using AirlineTicketSystem.Api.Dtos.FlightStatuses;
using AirlineTicketSystem.Api.Dtos.FlightStatusTransitions;
using AirlineTicketSystem.Api.Dtos.InvoiceItems;
using AirlineTicketSystem.Api.Dtos.InvoiceItemTypes;
using AirlineTicketSystem.Api.Dtos.Invoices;
using AirlineTicketSystem.Api.Dtos.Passengers;
using AirlineTicketSystem.Api.Dtos.PassengerTypes;
using AirlineTicketSystem.Api.Dtos.PaymentMethods;
using AirlineTicketSystem.Api.Dtos.PaymentMethodTypes;
using AirlineTicketSystem.Api.Dtos.Payments;
using AirlineTicketSystem.Api.Dtos.PaymentStatuses;
using AirlineTicketSystem.Api.Dtos.People;
using AirlineTicketSystem.Api.Dtos.Permissions;
using AirlineTicketSystem.Api.Dtos.PersonEmails;
using AirlineTicketSystem.Api.Dtos.PersonPhones;
using AirlineTicketSystem.Api.Dtos.PhoneCodes;
using AirlineTicketSystem.Api.Dtos.Regions;
using AirlineTicketSystem.Api.Dtos.ReservationFlights;
using AirlineTicketSystem.Api.Dtos.ReservationPassengers;
using AirlineTicketSystem.Api.Dtos.Reservations;
using AirlineTicketSystem.Api.Dtos.ReservationStatuses;
using AirlineTicketSystem.Api.Dtos.ReservationStatusTransitions;
using AirlineTicketSystem.Api.Dtos.RoadTypes;
using AirlineTicketSystem.Api.Dtos.RolePermissions;
using AirlineTicketSystem.Api.Dtos.Roles;
using AirlineTicketSystem.Api.Dtos.Routes;
using AirlineTicketSystem.Api.Dtos.RouteStops;
using AirlineTicketSystem.Api.Dtos.Seasons;
using AirlineTicketSystem.Api.Dtos.SeatLocationTypes;
using AirlineTicketSystem.Api.Dtos.Sessions;
using AirlineTicketSystem.Api.Dtos.Staff;
using AirlineTicketSystem.Api.Dtos.StaffAvailabilities;
using AirlineTicketSystem.Api.Dtos.StaffPositions;
using AirlineTicketSystem.Api.Dtos.Tickets;
using AirlineTicketSystem.Api.Dtos.TicketStatuses;
using AirlineTicketSystem.Api.Dtos.Users;
using AirlineTicketSystem.Application.UseCases.Address;
using AirlineTicketSystem.Application.UseCases.Aircraft;
using AirlineTicketSystem.Application.UseCases.AircraftManufacturer;
using AirlineTicketSystem.Application.UseCases.AircraftModel;
using AirlineTicketSystem.Application.UseCases.Airline;
using AirlineTicketSystem.Application.UseCases.Airport;
using AirlineTicketSystem.Application.UseCases.AirportAirline;
using AirlineTicketSystem.Application.UseCases.AvailabilityStatus;
using AirlineTicketSystem.Application.UseCases.CabinConfiguration;
using AirlineTicketSystem.Application.UseCases.CabinType;
using AirlineTicketSystem.Application.UseCases.CardIssuer;
using AirlineTicketSystem.Application.UseCases.CardType;
using AirlineTicketSystem.Application.UseCases.CheckIn;
using AirlineTicketSystem.Application.UseCases.CheckInStatus;
using AirlineTicketSystem.Application.UseCases.City;
using AirlineTicketSystem.Application.UseCases.Client;
using AirlineTicketSystem.Application.UseCases.Continent;
using AirlineTicketSystem.Application.UseCases.Country;
using AirlineTicketSystem.Application.UseCases.DocumentType;
using AirlineTicketSystem.Application.UseCases.EmailDomain;
using AirlineTicketSystem.Application.UseCases.Fare;
using AirlineTicketSystem.Application.UseCases.Flight;
using AirlineTicketSystem.Application.UseCases.FlightAssignment;
using AirlineTicketSystem.Application.UseCases.FlightRole;
using AirlineTicketSystem.Application.UseCases.FlightSeat;
using AirlineTicketSystem.Application.UseCases.FlightStatus;
using AirlineTicketSystem.Application.UseCases.FlightStatusTransition;
using AirlineTicketSystem.Application.UseCases.Invoice;
using AirlineTicketSystem.Application.UseCases.InvoiceItem;
using AirlineTicketSystem.Application.UseCases.InvoiceItemType;
using AirlineTicketSystem.Application.UseCases.Passenger;
using AirlineTicketSystem.Application.UseCases.PassengerType;
using AirlineTicketSystem.Application.UseCases.Payment;
using AirlineTicketSystem.Application.UseCases.PaymentMethod;
using AirlineTicketSystem.Application.UseCases.PaymentMethodType;
using AirlineTicketSystem.Application.UseCases.PaymentStatus;
using AirlineTicketSystem.Application.UseCases.Permission;
using AirlineTicketSystem.Application.UseCases.Person;
using AirlineTicketSystem.Application.UseCases.PersonEmail;
using AirlineTicketSystem.Application.UseCases.PersonPhone;
using AirlineTicketSystem.Application.UseCases.PhoneCode;
using AirlineTicketSystem.Application.UseCases.Region;
using AirlineTicketSystem.Application.UseCases.Reservation;
using AirlineTicketSystem.Application.UseCases.ReservationFlight;
using AirlineTicketSystem.Application.UseCases.ReservationPassenger;
using AirlineTicketSystem.Application.UseCases.ReservationStatus;
using AirlineTicketSystem.Application.UseCases.ReservationStatusTransition;
using AirlineTicketSystem.Application.UseCases.RoadType;
using AirlineTicketSystem.Application.UseCases.Role;
using AirlineTicketSystem.Application.UseCases.RolePermission;
using AirlineTicketSystem.Application.UseCases.Route;
using AirlineTicketSystem.Application.UseCases.RouteStop;
using AirlineTicketSystem.Application.UseCases.Season;
using AirlineTicketSystem.Application.UseCases.SeatLocationType;
using AirlineTicketSystem.Application.UseCases.Session;
using AirlineTicketSystem.Application.UseCases.Staff;
using AirlineTicketSystem.Application.UseCases.StaffAvailability;
using AirlineTicketSystem.Application.UseCases.StaffPosition;
using AirlineTicketSystem.Application.UseCases.Ticket;
using AirlineTicketSystem.Application.UseCases.TicketStatus;
using AirlineTicketSystem.Application.UseCases.User;
using AirlineTicketSystem.Domain.Entities;
using Mapster;

namespace AirlineTicketSystem.Api.Mappings;

public static class MappingConfig
{
    public static void RegisterMappings(TypeAdapterConfig config)
    {
        config.NewConfig<Airline, AirlineDto>();
        config.NewConfig<CreateAirlineRequest, CreateAirlineCommand>();

        config.NewConfig<Continent, ContinentDto>();
        config.NewConfig<CreateContinentRequest, CreateContinentCommand>();

        config.NewConfig<Country, CountryDto>();
        config.NewConfig<CreateCountryRequest, CreateCountryCommand>();

        config.NewConfig<Region, RegionDto>();
        config.NewConfig<CreateRegionRequest, CreateRegionCommand>();

        config.NewConfig<City, CityDto>();
        config.NewConfig<CreateCityRequest, CreateCityCommand>();

        config.NewConfig<RoadType, RoadTypeDto>();
        config.NewConfig<CreateRoadTypeRequest, CreateRoadTypeCommand>();

        config.NewConfig<DocumentType, DocumentTypeDto>();
        config.NewConfig<CreateDocumentTypeRequest, CreateDocumentTypeCommand>();

        config.NewConfig<CabinType, CabinTypeDto>();
        config.NewConfig<CreateCabinTypeRequest, CreateCabinTypeCommand>();

        config.NewConfig<PassengerType, PassengerTypeDto>();
        config.NewConfig<CreatePassengerTypeRequest, CreatePassengerTypeCommand>();

        config.NewConfig<FlightStatus, FlightStatusDto>();
        config.NewConfig<CreateFlightStatusRequest, CreateFlightStatusCommand>();

        config.NewConfig<ReservationStatus, ReservationStatusDto>();
        config.NewConfig<CreateReservationStatusRequest, CreateReservationStatusCommand>();

        config.NewConfig<TicketStatus, TicketStatusDto>();
        config.NewConfig<CreateTicketStatusRequest, CreateTicketStatusCommand>();

        config.NewConfig<CheckInStatus, CheckInStatusDto>();
        config.NewConfig<CreateCheckInStatusRequest, CreateCheckInStatusCommand>();

        config.NewConfig<PaymentStatus, PaymentStatusDto>();
        config.NewConfig<CreatePaymentStatusRequest, CreatePaymentStatusCommand>();

        config.NewConfig<PaymentMethodType, PaymentMethodTypeDto>();
        config.NewConfig<CreatePaymentMethodTypeRequest, CreatePaymentMethodTypeCommand>();

        config.NewConfig<CardIssuer, CardIssuerDto>();
        config.NewConfig<CreateCardIssuerRequest, CreateCardIssuerCommand>();

        config.NewConfig<CardType, CardTypeDto>();
        config.NewConfig<CreateCardTypeRequest, CreateCardTypeCommand>();

        config.NewConfig<AvailabilityStatus, AvailabilityStatusDto>();
        config.NewConfig<CreateAvailabilityStatusRequest, CreateAvailabilityStatusCommand>();

        config.NewConfig<Season, SeasonDto>();
        config.NewConfig<CreateSeasonRequest, CreateSeasonCommand>();

        config.NewConfig<InvoiceItemType, InvoiceItemTypeDto>();
        config.NewConfig<CreateInvoiceItemTypeRequest, CreateInvoiceItemTypeCommand>();

        config.NewConfig<FlightRole, FlightRoleDto>();
        config.NewConfig<CreateFlightRoleRequest, CreateFlightRoleCommand>();

        config.NewConfig<Permission, PermissionDto>();
        config.NewConfig<CreatePermissionRequest, CreatePermissionCommand>();

        config.NewConfig<SeatLocationType, SeatLocationTypeDto>();
        config.NewConfig<CreateSeatLocationTypeRequest, CreateSeatLocationTypeCommand>();

        config.NewConfig<Address, AddressDto>();
        config.NewConfig<CreateAddressRequest, CreateAddressCommand>();

        config.NewConfig<Person, PersonDto>();
        config.NewConfig<CreatePersonRequest, CreatePersonCommand>();

        config.NewConfig<EmailDomain, EmailDomainDto>();
        config.NewConfig<CreateEmailDomainRequest, CreateEmailDomainCommand>();

        config.NewConfig<PersonEmail, PersonEmailDto>();
        config.NewConfig<CreatePersonEmailRequest, CreatePersonEmailCommand>();

        config.NewConfig<PhoneCode, PhoneCodeDto>();
        config.NewConfig<CreatePhoneCodeRequest, CreatePhoneCodeCommand>();

        config.NewConfig<PersonPhone, PersonPhoneDto>();
        config.NewConfig<CreatePersonPhoneRequest, CreatePersonPhoneCommand>();

        config.NewConfig<Airport, AirportDto>();
        config.NewConfig<CreateAirportRequest, CreateAirportCommand>();

        config.NewConfig<AirportAirline, AirportAirlineDto>();
        config.NewConfig<CreateAirportAirlineRequest, CreateAirportAirlineCommand>();

        config.NewConfig<AircraftManufacturer, AircraftManufacturerDto>();
        config.NewConfig<CreateAircraftManufacturerRequest, CreateAircraftManufacturerCommand>();

        config.NewConfig<AircraftModel, AircraftModelDto>();
        config.NewConfig<CreateAircraftModelRequest, CreateAircraftModelCommand>();

        config.NewConfig<Aircraft, AircraftDto>();
        config.NewConfig<CreateAircraftRequest, CreateAircraftCommand>();

        config.NewConfig<CabinConfiguration, CabinConfigurationDto>();
        config.NewConfig<CreateCabinConfigurationRequest, CreateCabinConfigurationCommand>();

        config.NewConfig<AirlineTicketSystem.Domain.Entities.Route, RouteDto>();
        config.NewConfig<CreateRouteRequest, CreateRouteCommand>();

        config.NewConfig<RouteStop, RouteStopDto>();
        config.NewConfig<CreateRouteStopRequest, CreateRouteStopCommand>();

        config.NewConfig<Flight, FlightDto>();
        config.NewConfig<CreateFlightRequest, CreateFlightCommand>();

        config.NewConfig<FlightSeat, FlightSeatDto>();
        config.NewConfig<CreateFlightSeatRequest, CreateFlightSeatCommand>();

        config.NewConfig<Fare, FareDto>();
        config.NewConfig<CreateFareRequest, CreateFareCommand>();

        config.NewConfig<FlightAssignment, FlightAssignmentDto>();
        config.NewConfig<CreateFlightAssignmentRequest, CreateFlightAssignmentCommand>();

        config.NewConfig<FlightStatusTransition, FlightStatusTransitionDto>();
        config.NewConfig<CreateFlightStatusTransitionRequest, CreateFlightStatusTransitionCommand>();

        config.NewConfig<Passenger, PassengerDto>();
        config.NewConfig<CreatePassengerRequest, CreatePassengerCommand>();

        config.NewConfig<Client, ClientDto>();
        config.NewConfig<CreateClientRequest, CreateClientCommand>();

        config.NewConfig<Reservation, ReservationDto>();
        config.NewConfig<CreateReservationRequest, CreateReservationCommand>();

        config.NewConfig<ReservationFlight, ReservationFlightDto>();
        config.NewConfig<CreateReservationFlightRequest, CreateReservationFlightCommand>();

        config.NewConfig<ReservationPassenger, ReservationPassengerDto>();
        config.NewConfig<CreateReservationPassengerRequest, CreateReservationPassengerCommand>();

        config.NewConfig<ReservationStatusTransition, ReservationStatusTransitionDto>();
        config.NewConfig<CreateReservationStatusTransitionRequest, CreateReservationStatusTransitionCommand>();

        config.NewConfig<Ticket, TicketDto>();
        config.NewConfig<CreateTicketRequest, CreateTicketCommand>();

        config.NewConfig<StaffPosition, StaffPositionDto>();
        config.NewConfig<CreateStaffPositionRequest, CreateStaffPositionCommand>();

        config.NewConfig<Staff, StaffDto>();
        config.NewConfig<CreateStaffRequest, CreateStaffCommand>();

        config.NewConfig<StaffAvailability, StaffAvailabilityDto>();
        config.NewConfig<CreateStaffAvailabilityRequest, CreateStaffAvailabilityCommand>();

        config.NewConfig<CheckIn, CheckInDto>();
        config.NewConfig<CreateCheckInRequest, CreateCheckInCommand>();

        config.NewConfig<Invoice, InvoiceDto>();
        config.NewConfig<CreateInvoiceRequest, CreateInvoiceCommand>();

        config.NewConfig<InvoiceItem, InvoiceItemDto>();
        config.NewConfig<CreateInvoiceItemRequest, CreateInvoiceItemCommand>();

        config.NewConfig<PaymentMethod, PaymentMethodDto>();
        config.NewConfig<CreatePaymentMethodRequest, CreatePaymentMethodCommand>();

        config.NewConfig<Payment, PaymentDto>();
        config.NewConfig<CreatePaymentRequest, CreatePaymentCommand>();

        config.NewConfig<Role, RoleDto>();
        config.NewConfig<CreateRoleRequest, CreateRoleCommand>();

        config.NewConfig<RolePermission, RolePermissionDto>();
        config.NewConfig<CreateRolePermissionRequest, CreateRolePermissionCommand>();

        config.NewConfig<User, UserDto>();
        config.NewConfig<CreateUserRequest, CreateUserCommand>();

        config.NewConfig<Session, SessionDto>();
        config.NewConfig<CreateSessionRequest, CreateSessionCommand>();
    }
}
