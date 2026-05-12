using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Infrastructure.Context;
using AirlineTicketSystem.Infrastructure.Repositories;
using AirlineTicketSystem.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirlineTicketSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IAirline, AirlineRepository>();
        services.AddScoped<IContinent, ContinentRepository>();
        services.AddScoped<ICountry, CountryRepository>();
        services.AddScoped<IRegion, RegionRepository>();
        services.AddScoped<ICity, CityRepository>();
        services.AddScoped<IRoadType, RoadTypeRepository>();
        services.AddScoped<IDocumentType, DocumentTypeRepository>();
        services.AddScoped<ICabinType, CabinTypeRepository>();
        services.AddScoped<IPassengerType, PassengerTypeRepository>();
        services.AddScoped<IFlightStatus, FlightStatusRepository>();
        services.AddScoped<IReservationStatus, ReservationStatusRepository>();
        services.AddScoped<ITicketStatus, TicketStatusRepository>();
        services.AddScoped<ICheckInStatus, CheckInStatusRepository>();
        services.AddScoped<IPaymentStatus, PaymentStatusRepository>();
        services.AddScoped<IPaymentMethodType, PaymentMethodTypeRepository>();
        services.AddScoped<ICardIssuer, CardIssuerRepository>();
        services.AddScoped<ICardType, CardTypeRepository>();
        services.AddScoped<IAvailabilityStatus, AvailabilityStatusRepository>();
        services.AddScoped<ISeason, SeasonRepository>();
        services.AddScoped<IInvoiceItemType, InvoiceItemTypeRepository>();
        services.AddScoped<IFlightRole, FlightRoleRepository>();
        services.AddScoped<IPermission, PermissionRepository>();
        services.AddScoped<ISeatLocationType, SeatLocationTypeRepository>();
        services.AddScoped<IAddress, AddressRepository>();
        services.AddScoped<IPerson, PersonRepository>();
        services.AddScoped<IEmailDomain, EmailDomainRepository>();
        services.AddScoped<IPersonEmail, PersonEmailRepository>();
        services.AddScoped<IPhoneCode, PhoneCodeRepository>();
        services.AddScoped<IPersonPhone, PersonPhoneRepository>();
        services.AddScoped<IAirport, AirportRepository>();
        services.AddScoped<IAirportAirline, AirportAirlineRepository>();
        services.AddScoped<IAircraftManufacturer, AircraftManufacturerRepository>();
        services.AddScoped<IAircraftModel, AircraftModelRepository>();
        services.AddScoped<IAircraft, AircraftRepository>();
        services.AddScoped<ICabinConfiguration, CabinConfigurationRepository>();
        services.AddScoped<IRoute, RouteRepository>();
        services.AddScoped<IRouteStop, RouteStopRepository>();
        services.AddScoped<IFlight, FlightRepository>();
        services.AddScoped<IFlightSeat, FlightSeatRepository>();
        services.AddScoped<IFare, FareRepository>();
        services.AddScoped<IFlightAssignment, FlightAssignmentRepository>();
        services.AddScoped<IFlightStatusTransition, FlightStatusTransitionRepository>();
        services.AddScoped<IPassenger, PassengerRepository>();
        services.AddScoped<IClient, ClientRepository>();
        services.AddScoped<IReservation, ReservationRepository>();
        services.AddScoped<IReservationFlight, ReservationFlightRepository>();
        services.AddScoped<IReservationPassenger, ReservationPassengerRepository>();
        services.AddScoped<IReservationStatusTransition, ReservationStatusTransitionRepository>();
        services.AddScoped<ITicket, TicketRepository>();
        services.AddScoped<IStaffPosition, StaffPositionRepository>();
        services.AddScoped<IStaff, StaffRepository>();
        services.AddScoped<IStaffAvailability, StaffAvailabilityRepository>();
        services.AddScoped<ICheckIn, CheckInRepository>();
        services.AddScoped<IInvoice, InvoiceRepository>();
        services.AddScoped<IInvoiceItem, InvoiceItemRepository>();
        services.AddScoped<IPaymentMethod, PaymentMethodRepository>();
        services.AddScoped<IPayment, PaymentRepository>();
        services.AddScoped<IRole, RoleRepository>();
        services.AddScoped<IRolePermission, RolePermissionRepository>();
        services.AddScoped<IUser, UserRepository>();
        services.AddScoped<ISession, SessionRepository>();
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();

        return services;
    }
}
