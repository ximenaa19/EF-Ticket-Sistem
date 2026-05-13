using System.Linq.Expressions;
using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Entities;
using AirlineTicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AirlineTicketSystem.Infrastructure.Seeding;

public static class DbInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await using var transaction = await context.Database.BeginTransactionAsync();

        try
        {
            var americas = await GetOrCreateAsync(
                context,
                entity => entity.Name == "Americas",
                () => new Continent("Americas"));

            var usa = await GetOrCreateAsync(
                context,
                entity => entity.IsoCode == "USA",
                () => new Country("United States", "USA", americas.Id));

            var mexico = await GetOrCreateAsync(
                context,
                entity => entity.IsoCode == "MEX",
                () => new Country("Mexico", "MEX", americas.Id));

            var northeastUS = await GetOrCreateAsync(
                context,
                entity => entity.Name == "Northeast US",
                () => new Region("Northeast US", usa.Id));

            var centralMexico = await GetOrCreateAsync(
                context,
                entity => entity.Name == "Central Mexico",
                () => new Region("Central Mexico", mexico.Id));

            var newYork = await GetOrCreateAsync(
                context,
                entity => entity.Name == "New York",
                () => new City("New York", northeastUS.Id));

            var mexicoCity = await GetOrCreateAsync(
                context,
                entity => entity.Name == "Mexico City",
                () => new City("Mexico City", centralMexico.Id));

            var documentTypePassport = await GetOrCreateAsync(
                context,
                entity => entity.Name == "Passport",
                () => new DocumentType("Passport"));

            await GetOrCreateAsync(
                context,
                entity => entity.Name == "gmail.com",
                () => new EmailDomain("gmail.com"));

            var availabilityAvailable = await GetOrCreateAsync(
                context,
                entity => entity.Name == "Available",
                () => new AvailabilityStatus("Available"));

            var cabinEconomy = await GetOrCreateAsync(
                context,
                entity => entity.Name == "Economy",
                () => new CabinType("Economy"));

            var cabinBusiness = await GetOrCreateAsync(
                context,
                entity => entity.Name == "Business",
                () => new CabinType("Business"));

            var passengerAdult = await GetOrCreateAsync(
                context,
                entity => entity.Name == "Adult",
                () => new PassengerType("Adult"));

            await GetOrCreateAsync(
                context,
                entity => entity.Name == "Child",
                () => new PassengerType("Child"));

            var flightStatusScheduled = await GetOrCreateAsync(
                context,
                entity => entity.Name == "Scheduled",
                () => new FlightStatus("Scheduled"));

            await GetOrCreateAsync(
                context,
                entity => entity.Name == "Departed",
                () => new FlightStatus("Departed"));

            await GetOrCreateAsync(
                context,
                entity => entity.Name == "Confirmed",
                () => new ReservationStatus("Confirmed"));

            var airline = await GetOrCreateAsync(
                context,
                entity => entity.IataCode == "AMX",
                () => new Airline("Aeromexico", "AMX"));

            var airportJFK = await GetOrCreateAsync(
                context,
                entity => entity.IataCode == "JFK",
                () => new Airport("John F. Kennedy International Airport", "JFK", "KJFK", newYork.Id));

            var airportMEX = await GetOrCreateAsync(
                context,
                entity => entity.IataCode == "MEX",
                () => new Airport("Mexico City International Airport", "MEX", "MMMX", mexicoCity.Id));

            var route = await GetOrCreateAsync(
                context,
                entity => entity.OriginAirportId == airportJFK.Id && entity.DestinationAirportId == airportMEX.Id,
                () => new Route(airportJFK.Id, airportMEX.Id, 4020.00m));

            var manufacturer = await GetOrCreateAsync(
                context,
                entity => entity.Name == "Boeing",
                () => new AircraftManufacturer("Boeing"));

            var aircraftModel = await GetOrCreateAsync(
                context,
                entity => entity.Name == "737 MAX 8",
                () => new AircraftModel("737 MAX 8", manufacturer.Id));

            var aircraft = await GetOrCreateAsync(
                context,
                entity => entity.RegistrationNumber == "XA-ERO1",
                () => new Aircraft("XA-ERO1", airline.Id, aircraftModel.Id, availabilityAvailable.Id, 180));

            var flight = await GetOrCreateAsync(
                context,
                entity => entity.FlightCode == "AMX100",
                () => new Flight(
                    "AMX100",
                    airline.Id,
                    route.Id,
                    aircraft.Id,
                    DateTime.Parse("2026-06-01T10:00:00Z").ToUniversalTime(),
                    DateTime.Parse("2026-06-01T17:30:00Z").ToUniversalTime(),
                    180,
                    180,
                    flightStatusScheduled.Id));

            await GetOrCreateAsync(
                context,
                entity => entity.FlightId == flight.Id && entity.PassengerTypeId == passengerAdult.Id && entity.CabinTypeId == cabinEconomy.Id,
                () => new Fare(flight.Id, passengerAdult.Id, cabinEconomy.Id, 450.00m, "USD"));

            await GetOrCreateAsync(
                context,
                entity => entity.FlightId == flight.Id && entity.PassengerTypeId == passengerAdult.Id && entity.CabinTypeId == cabinBusiness.Id,
                () => new Fare(flight.Id, passengerAdult.Id, cabinBusiness.Id, 950.00m, "USD"));

            var person = await GetOrCreateAsync(
                context,
                entity => entity.DocumentNumber == "P12345678",
                () => new Person("Carlos", "Ramirez", documentTypePassport.Id, "P12345678", new DateTime(1987, 8, 10, 0, 0, 0, DateTimeKind.Utc), null));

            await GetOrCreateAsync(
                context,
                entity => entity.PersonId == person.Id,
                () => new Client(person.Id));

            await context.SaveChangesAsync();
            await transaction.CommitAsync();

            Console.WriteLine("Seed data initialized successfully.");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            Console.WriteLine($"Error initializing seed data: {ex.Message}");
            throw;
        }
    }

    private static async Task<TEntity> GetOrCreateAsync<TEntity>(
        AppDbContext context,
        Expression<Func<TEntity, bool>> predicate,
        Func<TEntity> createEntity)
        where TEntity : BaseEntity
    {
        var entity = await context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        if (entity is not null)
        {
            return entity;
        }

        entity = createEntity();
        await context.Set<TEntity>().AddAsync(entity);

        return entity;
    }
}
