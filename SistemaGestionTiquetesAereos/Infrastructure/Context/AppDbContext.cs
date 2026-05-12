using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketSystem.Infrastructure.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Airline> Airlines => Set<Airline>();
    public DbSet<Continent> Continents => Set<Continent>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Region> Regions => Set<Region>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<RoadType> RoadTypes => Set<RoadType>();
    public DbSet<DocumentType> DocumentTypes => Set<DocumentType>();
    public DbSet<CabinType> CabinTypes => Set<CabinType>();
    public DbSet<PassengerType> PassengerTypes => Set<PassengerType>();
    public DbSet<FlightStatus> FlightStatuses => Set<FlightStatus>();
    public DbSet<ReservationStatus> ReservationStatuses => Set<ReservationStatus>();
    public DbSet<TicketStatus> TicketStatuses => Set<TicketStatus>();
    public DbSet<CheckInStatus> CheckInStatuses => Set<CheckInStatus>();
    public DbSet<PaymentStatus> PaymentStatuses => Set<PaymentStatus>();
    public DbSet<PaymentMethodType> PaymentMethodTypes => Set<PaymentMethodType>();
    public DbSet<CardIssuer> CardIssuers => Set<CardIssuer>();
    public DbSet<CardType> CardTypes => Set<CardType>();
    public DbSet<AvailabilityStatus> AvailabilityStatuses => Set<AvailabilityStatus>();
    public DbSet<Season> Seasons => Set<Season>();
    public DbSet<InvoiceItemType> InvoiceItemTypes => Set<InvoiceItemType>();
    public DbSet<FlightRole> FlightRoles => Set<FlightRole>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<SeatLocationType> SeatLocationTypes => Set<SeatLocationType>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Person> People => Set<Person>();
    public DbSet<EmailDomain> EmailDomains => Set<EmailDomain>();
    public DbSet<PersonEmail> PersonEmails => Set<PersonEmail>();
    public DbSet<PhoneCode> PhoneCodes => Set<PhoneCode>();
    public DbSet<PersonPhone> PersonPhones => Set<PersonPhone>();
    public DbSet<Airport> Airports => Set<Airport>();
    public DbSet<AirportAirline> AirportAirlines => Set<AirportAirline>();
    public DbSet<AircraftManufacturer> AircraftManufacturers => Set<AircraftManufacturer>();
    public DbSet<AircraftModel> AircraftModels => Set<AircraftModel>();
    public DbSet<Aircraft> Aircraft => Set<Aircraft>();
    public DbSet<CabinConfiguration> CabinConfigurations => Set<CabinConfiguration>();
    public DbSet<Route> Routes => Set<Route>();
    public DbSet<RouteStop> RouteStops => Set<RouteStop>();
    public DbSet<Flight> Flights => Set<Flight>();
    public DbSet<FlightSeat> FlightSeats => Set<FlightSeat>();
    public DbSet<Fare> Fares => Set<Fare>();
    public DbSet<FlightAssignment> FlightAssignments => Set<FlightAssignment>();
    public DbSet<FlightStatusTransition> FlightStatusTransitions => Set<FlightStatusTransition>();
    public DbSet<Passenger> Passengers => Set<Passenger>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<ReservationFlight> ReservationFlights => Set<ReservationFlight>();
    public DbSet<ReservationPassenger> ReservationPassengers => Set<ReservationPassenger>();
    public DbSet<ReservationStatusTransition> ReservationStatusTransitions => Set<ReservationStatusTransition>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<StaffPosition> StaffPositions => Set<StaffPosition>();
    public DbSet<Staff> Staff => Set<Staff>();
    public DbSet<StaffAvailability> StaffAvailabilities => Set<StaffAvailability>();
    public DbSet<CheckIn> CheckIns => Set<CheckIn>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();
    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Session> Sessions => Set<Session>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
