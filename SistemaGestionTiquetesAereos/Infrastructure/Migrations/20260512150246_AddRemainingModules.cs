using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineTicketSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRemainingModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aircraft_manufacturers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aircraft_manufacturers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "availability_statuses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_availability_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cabin_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cabin_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "card_issuers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_card_issuers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "card_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_card_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "check_in_statuses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_check_in_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    iso_code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    continent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.id);
                    table.ForeignKey(
                        name: "FK_countries_continents_continent_id",
                        column: x => x.continent_id,
                        principalTable: "continents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "document_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "email_domains",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email_domains", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "flight_roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flight_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "flight_statuses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flight_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "invoice_item_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice_item_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "passenger_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passenger_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payment_method_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_method_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payment_statuses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    code = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reservation_statuses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "road_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_road_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "seasons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seasons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "seat_location_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seat_location_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "staff_positions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff_positions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ticket_statuses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aircraft_models",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    aircraft_manufacturer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aircraft_models", x => x.id);
                    table.ForeignKey(
                        name: "FK_aircraft_models_aircraft_manufacturers_aircraft_manufacture~",
                        column: x => x.aircraft_manufacturer_id,
                        principalTable: "aircraft_manufacturers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "phone_codes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    country_id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phone_codes", x => x.id);
                    table.ForeignKey(
                        name: "FK_phone_codes_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "regions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    country_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regions", x => x.id);
                    table.ForeignKey(
                        name: "FK_regions_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    permission_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_permissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_role_permissions_permissions_permission_id",
                        column: x => x.permission_id,
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_role_permissions_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "aircraft",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    registration_number = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    airline_id = table.Column<Guid>(type: "uuid", nullable: false),
                    aircraft_model_id = table.Column<Guid>(type: "uuid", nullable: false),
                    availability_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    total_capacity = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aircraft", x => x.id);
                    table.ForeignKey(
                        name: "FK_aircraft_aircraft_models_aircraft_model_id",
                        column: x => x.aircraft_model_id,
                        principalTable: "aircraft_models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_aircraft_airlines_airline_id",
                        column: x => x.airline_id,
                        principalTable: "airlines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_aircraft_availability_statuses_availability_status_id",
                        column: x => x.availability_status_id,
                        principalTable: "availability_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    region_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.id);
                    table.ForeignKey(
                        name: "FK_cities_regions_region_id",
                        column: x => x.region_id,
                        principalTable: "regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cabin_configurations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    aircraft_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cabin_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    seat_count = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cabin_configurations", x => x.id);
                    table.ForeignKey(
                        name: "FK_cabin_configurations_aircraft_aircraft_id",
                        column: x => x.aircraft_id,
                        principalTable: "aircraft",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cabin_configurations_cabin_types_cabin_type_id",
                        column: x => x.cabin_type_id,
                        principalTable: "cabin_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    road_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    city_id = table.Column<Guid>(type: "uuid", nullable: false),
                    street = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    number = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    additional_info = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_addresses_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_addresses_road_types_road_type_id",
                        column: x => x.road_type_id,
                        principalTable: "road_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "airports",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    iata_code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    icao_code = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    city_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airports", x => x.id);
                    table.ForeignKey(
                        name: "FK_airports_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    document_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    document_number = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    address_id = table.Column<Guid>(type: "uuid", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.id);
                    table.ForeignKey(
                        name: "FK_people_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_people_document_types_document_type_id",
                        column: x => x.document_type_id,
                        principalTable: "document_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "airport_airlines",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    airport_id = table.Column<Guid>(type: "uuid", nullable: false),
                    airline_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airport_airlines", x => x.id);
                    table.ForeignKey(
                        name: "FK_airport_airlines_airlines_airline_id",
                        column: x => x.airline_id,
                        principalTable: "airlines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_airport_airlines_airports_airport_id",
                        column: x => x.airport_id,
                        principalTable: "airports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    origin_airport_id = table.Column<Guid>(type: "uuid", nullable: false),
                    destination_airport_id = table.Column<Guid>(type: "uuid", nullable: false),
                    distance_km = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routes", x => x.id);
                    table.ForeignKey(
                        name: "FK_routes_airports_destination_airport_id",
                        column: x => x.destination_airport_id,
                        principalTable: "airports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_routes_airports_origin_airport_id",
                        column: x => x.origin_airport_id,
                        principalTable: "airports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    person_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                    table.ForeignKey(
                        name: "FK_clients_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "passengers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    person_id = table.Column<Guid>(type: "uuid", nullable: false),
                    passenger_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passengers", x => x.id);
                    table.ForeignKey(
                        name: "FK_passengers_passenger_types_passenger_type_id",
                        column: x => x.passenger_type_id,
                        principalTable: "passenger_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_passengers_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "person_emails",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    person_id = table.Column<Guid>(type: "uuid", nullable: false),
                    email_domain_id = table.Column<Guid>(type: "uuid", nullable: false),
                    local_part = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    is_primary = table.Column<bool>(type: "boolean", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_emails", x => x.id);
                    table.ForeignKey(
                        name: "FK_person_emails_email_domains_email_domain_id",
                        column: x => x.email_domain_id,
                        principalTable: "email_domains",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_person_emails_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "person_phones",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    person_id = table.Column<Guid>(type: "uuid", nullable: false),
                    phone_code_id = table.Column<Guid>(type: "uuid", nullable: false),
                    number = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    is_primary = table.Column<bool>(type: "boolean", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_phones", x => x.id);
                    table.ForeignKey(
                        name: "FK_person_phones_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_person_phones_phone_codes_phone_code_id",
                        column: x => x.phone_code_id,
                        principalTable: "phone_codes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "staff",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    person_id = table.Column<Guid>(type: "uuid", nullable: false),
                    staff_position_id = table.Column<Guid>(type: "uuid", nullable: false),
                    employee_code = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff", x => x.id);
                    table.ForeignKey(
                        name: "FK_staff_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_staff_staff_positions_staff_position_id",
                        column: x => x.staff_position_id,
                        principalTable: "staff_positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    person_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    password_hash = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "flights",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    flight_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    airline_id = table.Column<Guid>(type: "uuid", nullable: false),
                    route_id = table.Column<Guid>(type: "uuid", nullable: false),
                    aircraft_id = table.Column<Guid>(type: "uuid", nullable: false),
                    departure_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    estimated_arrival_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    total_capacity = table.Column<int>(type: "integer", nullable: false),
                    available_seats = table.Column<int>(type: "integer", nullable: false),
                    flight_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flights", x => x.id);
                    table.ForeignKey(
                        name: "FK_flights_aircraft_aircraft_id",
                        column: x => x.aircraft_id,
                        principalTable: "aircraft",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flights_airlines_airline_id",
                        column: x => x.airline_id,
                        principalTable: "airlines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flights_flight_statuses_flight_status_id",
                        column: x => x.flight_status_id,
                        principalTable: "flight_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flights_routes_route_id",
                        column: x => x.route_id,
                        principalTable: "routes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "route_stops",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    route_id = table.Column<Guid>(type: "uuid", nullable: false),
                    airport_id = table.Column<Guid>(type: "uuid", nullable: false),
                    stop_order = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_route_stops", x => x.id);
                    table.ForeignKey(
                        name: "FK_route_stops_airports_airport_id",
                        column: x => x.airport_id,
                        principalTable: "airports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_route_stops_routes_route_id",
                        column: x => x.route_id,
                        principalTable: "routes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payment_methods",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    client_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payment_method_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    card_issuer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    card_type_id = table.Column<Guid>(type: "uuid", nullable: true),
                    masked_number = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_methods", x => x.id);
                    table.ForeignKey(
                        name: "FK_payment_methods_card_issuers_card_issuer_id",
                        column: x => x.card_issuer_id,
                        principalTable: "card_issuers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_payment_methods_card_types_card_type_id",
                        column: x => x.card_type_id,
                        principalTable: "card_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_payment_methods_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_payment_methods_payment_method_types_payment_method_type_id",
                        column: x => x.payment_method_type_id,
                        principalTable: "payment_method_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    client_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reservation_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reservation_code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    reserved_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    total_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_reservations_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reservations_reservation_statuses_reservation_status_id",
                        column: x => x.reservation_status_id,
                        principalTable: "reservation_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "staff_availabilities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    staff_id = table.Column<Guid>(type: "uuid", nullable: false),
                    availability_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    available_from = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    available_to = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff_availabilities", x => x.id);
                    table.ForeignKey(
                        name: "FK_staff_availabilities_availability_statuses_availability_sta~",
                        column: x => x.availability_status_id,
                        principalTable: "availability_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_staff_availabilities_staff_staff_id",
                        column: x => x.staff_id,
                        principalTable: "staff",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sessions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    token = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    expires_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    revoked_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessions", x => x.id);
                    table.ForeignKey(
                        name: "FK_sessions_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fares",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    flight_id = table.Column<Guid>(type: "uuid", nullable: false),
                    passenger_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cabin_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fares", x => x.id);
                    table.ForeignKey(
                        name: "FK_fares_cabin_types_cabin_type_id",
                        column: x => x.cabin_type_id,
                        principalTable: "cabin_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fares_flights_flight_id",
                        column: x => x.flight_id,
                        principalTable: "flights",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fares_passenger_types_passenger_type_id",
                        column: x => x.passenger_type_id,
                        principalTable: "passenger_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "flight_assignments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    flight_id = table.Column<Guid>(type: "uuid", nullable: false),
                    staff_id = table.Column<Guid>(type: "uuid", nullable: false),
                    flight_role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flight_assignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_flight_assignments_flight_roles_flight_role_id",
                        column: x => x.flight_role_id,
                        principalTable: "flight_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flight_assignments_flights_flight_id",
                        column: x => x.flight_id,
                        principalTable: "flights",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flight_assignments_staff_staff_id",
                        column: x => x.staff_id,
                        principalTable: "staff",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "flight_seats",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    flight_id = table.Column<Guid>(type: "uuid", nullable: false),
                    seat_number = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    cabin_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    seat_location_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    availability_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flight_seats", x => x.id);
                    table.ForeignKey(
                        name: "FK_flight_seats_availability_statuses_availability_status_id",
                        column: x => x.availability_status_id,
                        principalTable: "availability_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flight_seats_cabin_types_cabin_type_id",
                        column: x => x.cabin_type_id,
                        principalTable: "cabin_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flight_seats_flights_flight_id",
                        column: x => x.flight_id,
                        principalTable: "flights",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flight_seats_seat_location_types_seat_location_type_id",
                        column: x => x.seat_location_type_id,
                        principalTable: "seat_location_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "flight_status_transitions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    flight_id = table.Column<Guid>(type: "uuid", nullable: false),
                    from_flight_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    to_flight_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    changed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flight_status_transitions", x => x.id);
                    table.ForeignKey(
                        name: "FK_flight_status_transitions_flight_statuses_from_flight_statu~",
                        column: x => x.from_flight_status_id,
                        principalTable: "flight_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flight_status_transitions_flight_statuses_to_flight_status_~",
                        column: x => x.to_flight_status_id,
                        principalTable: "flight_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flight_status_transitions_flights_flight_id",
                        column: x => x.flight_id,
                        principalTable: "flights",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    reservation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    invoice_number = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    issued_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    total_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_invoices_reservations_reservation_id",
                        column: x => x.reservation_id,
                        principalTable: "reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    reservation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payment_method_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payment_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    paid_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_payments_payment_methods_payment_method_id",
                        column: x => x.payment_method_id,
                        principalTable: "payment_methods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_payments_payment_statuses_payment_status_id",
                        column: x => x.payment_status_id,
                        principalTable: "payment_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_payments_reservations_reservation_id",
                        column: x => x.reservation_id,
                        principalTable: "reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reservation_flights",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    reservation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    flight_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation_flights", x => x.id);
                    table.ForeignKey(
                        name: "FK_reservation_flights_flights_flight_id",
                        column: x => x.flight_id,
                        principalTable: "flights",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reservation_flights_reservations_reservation_id",
                        column: x => x.reservation_id,
                        principalTable: "reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reservation_passengers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    reservation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    passenger_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation_passengers", x => x.id);
                    table.ForeignKey(
                        name: "FK_reservation_passengers_passengers_passenger_id",
                        column: x => x.passenger_id,
                        principalTable: "passengers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reservation_passengers_reservations_reservation_id",
                        column: x => x.reservation_id,
                        principalTable: "reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reservation_status_transitions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    reservation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    from_reservation_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    to_reservation_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    changed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation_status_transitions", x => x.id);
                    table.ForeignKey(
                        name: "FK_reservation_status_transitions_reservation_statuses_from_re~",
                        column: x => x.from_reservation_status_id,
                        principalTable: "reservation_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reservation_status_transitions_reservation_statuses_to_rese~",
                        column: x => x.to_reservation_status_id,
                        principalTable: "reservation_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reservation_status_transitions_reservations_reservation_id",
                        column: x => x.reservation_id,
                        principalTable: "reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    reservation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    passenger_id = table.Column<Guid>(type: "uuid", nullable: false),
                    flight_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ticket_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ticket_number = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    fare_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.id);
                    table.ForeignKey(
                        name: "FK_tickets_flights_flight_id",
                        column: x => x.flight_id,
                        principalTable: "flights",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tickets_passengers_passenger_id",
                        column: x => x.passenger_id,
                        principalTable: "passengers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tickets_reservations_reservation_id",
                        column: x => x.reservation_id,
                        principalTable: "reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tickets_ticket_statuses_ticket_status_id",
                        column: x => x.ticket_status_id,
                        principalTable: "ticket_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "invoice_items",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    invoice_id = table.Column<Guid>(type: "uuid", nullable: false),
                    invoice_item_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_invoice_items_invoice_item_types_invoice_item_type_id",
                        column: x => x.invoice_item_type_id,
                        principalTable: "invoice_item_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_invoice_items_invoices_invoice_id",
                        column: x => x.invoice_id,
                        principalTable: "invoices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "check_ins",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ticket_id = table.Column<Guid>(type: "uuid", nullable: false),
                    check_in_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    seat_id = table.Column<Guid>(type: "uuid", nullable: true),
                    checked_in_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_check_ins", x => x.id);
                    table.ForeignKey(
                        name: "FK_check_ins_check_in_statuses_check_in_status_id",
                        column: x => x.check_in_status_id,
                        principalTable: "check_in_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_check_ins_flight_seats_seat_id",
                        column: x => x.seat_id,
                        principalTable: "flight_seats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_check_ins_tickets_ticket_id",
                        column: x => x.ticket_id,
                        principalTable: "tickets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_city_id",
                table: "addresses",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_road_type_id",
                table: "addresses",
                column: "road_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_aircraft_aircraft_model_id",
                table: "aircraft",
                column: "aircraft_model_id");

            migrationBuilder.CreateIndex(
                name: "IX_aircraft_airline_id",
                table: "aircraft",
                column: "airline_id");

            migrationBuilder.CreateIndex(
                name: "IX_aircraft_availability_status_id",
                table: "aircraft",
                column: "availability_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_aircraft_registration_number",
                table: "aircraft",
                column: "registration_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_aircraft_manufacturers_name",
                table: "aircraft_manufacturers",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_aircraft_models_aircraft_manufacturer_id",
                table: "aircraft_models",
                column: "aircraft_manufacturer_id");

            migrationBuilder.CreateIndex(
                name: "IX_aircraft_models_name",
                table: "aircraft_models",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_airport_airlines_airline_id",
                table: "airport_airlines",
                column: "airline_id");

            migrationBuilder.CreateIndex(
                name: "IX_airport_airlines_airport_id",
                table: "airport_airlines",
                column: "airport_id");

            migrationBuilder.CreateIndex(
                name: "IX_airports_city_id",
                table: "airports",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_airports_iata_code",
                table: "airports",
                column: "iata_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_availability_statuses_name",
                table: "availability_statuses",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cabin_configurations_aircraft_id",
                table: "cabin_configurations",
                column: "aircraft_id");

            migrationBuilder.CreateIndex(
                name: "IX_cabin_configurations_cabin_type_id",
                table: "cabin_configurations",
                column: "cabin_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_cabin_types_name",
                table: "cabin_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_card_issuers_name",
                table: "card_issuers",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_card_types_name",
                table: "card_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_check_in_statuses_name",
                table: "check_in_statuses",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_check_ins_check_in_status_id",
                table: "check_ins",
                column: "check_in_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_check_ins_seat_id",
                table: "check_ins",
                column: "seat_id");

            migrationBuilder.CreateIndex(
                name: "IX_check_ins_ticket_id",
                table: "check_ins",
                column: "ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_cities_name",
                table: "cities",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cities_region_id",
                table: "cities",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "IX_clients_person_id",
                table: "clients",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_countries_continent_id",
                table: "countries",
                column: "continent_id");

            migrationBuilder.CreateIndex(
                name: "IX_countries_name",
                table: "countries",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_document_types_name",
                table: "document_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_email_domains_name",
                table: "email_domains",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fares_cabin_type_id",
                table: "fares",
                column: "cabin_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_fares_flight_id",
                table: "fares",
                column: "flight_id");

            migrationBuilder.CreateIndex(
                name: "IX_fares_passenger_type_id",
                table: "fares",
                column: "passenger_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_flight_assignments_flight_id",
                table: "flight_assignments",
                column: "flight_id");

            migrationBuilder.CreateIndex(
                name: "IX_flight_assignments_flight_role_id",
                table: "flight_assignments",
                column: "flight_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_flight_assignments_staff_id",
                table: "flight_assignments",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_flight_roles_name",
                table: "flight_roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_flight_seats_availability_status_id",
                table: "flight_seats",
                column: "availability_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_flight_seats_cabin_type_id",
                table: "flight_seats",
                column: "cabin_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_flight_seats_flight_id",
                table: "flight_seats",
                column: "flight_id");

            migrationBuilder.CreateIndex(
                name: "IX_flight_seats_seat_location_type_id",
                table: "flight_seats",
                column: "seat_location_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_flight_status_transitions_flight_id",
                table: "flight_status_transitions",
                column: "flight_id");

            migrationBuilder.CreateIndex(
                name: "IX_flight_status_transitions_from_flight_status_id",
                table: "flight_status_transitions",
                column: "from_flight_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_flight_status_transitions_to_flight_status_id",
                table: "flight_status_transitions",
                column: "to_flight_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_flight_statuses_name",
                table: "flight_statuses",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_flights_aircraft_id",
                table: "flights",
                column: "aircraft_id");

            migrationBuilder.CreateIndex(
                name: "IX_flights_airline_id",
                table: "flights",
                column: "airline_id");

            migrationBuilder.CreateIndex(
                name: "IX_flights_flight_code",
                table: "flights",
                column: "flight_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_flights_flight_status_id",
                table: "flights",
                column: "flight_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_flights_route_id",
                table: "flights",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_item_types_name",
                table: "invoice_item_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoice_items_invoice_id",
                table: "invoice_items",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_items_invoice_item_type_id",
                table: "invoice_items",
                column: "invoice_item_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_invoice_number",
                table: "invoices",
                column: "invoice_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoices_reservation_id",
                table: "invoices",
                column: "reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_passenger_types_name",
                table: "passenger_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_passengers_passenger_type_id",
                table: "passengers",
                column: "passenger_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_passengers_person_id",
                table: "passengers",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_method_types_name",
                table: "payment_method_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_payment_methods_card_issuer_id",
                table: "payment_methods",
                column: "card_issuer_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_methods_card_type_id",
                table: "payment_methods",
                column: "card_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_methods_client_id",
                table: "payment_methods",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_methods_payment_method_type_id",
                table: "payment_methods",
                column: "payment_method_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_statuses_name",
                table: "payment_statuses",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_payments_payment_method_id",
                table: "payments",
                column: "payment_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_payment_status_id",
                table: "payments",
                column: "payment_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_reservation_id",
                table: "payments",
                column: "reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_people_address_id",
                table: "people",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_people_document_number",
                table: "people",
                column: "document_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_people_document_type_id",
                table: "people",
                column: "document_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_permissions_code",
                table: "permissions",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_person_emails_email_domain_id",
                table: "person_emails",
                column: "email_domain_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_emails_person_id",
                table: "person_emails",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_phones_person_id",
                table: "person_phones",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_phones_phone_code_id",
                table: "person_phones",
                column: "phone_code_id");

            migrationBuilder.CreateIndex(
                name: "IX_phone_codes_code",
                table: "phone_codes",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_phone_codes_country_id",
                table: "phone_codes",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_regions_country_id",
                table: "regions",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_regions_name",
                table: "regions",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reservation_flights_flight_id",
                table: "reservation_flights",
                column: "flight_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_flights_reservation_id",
                table: "reservation_flights",
                column: "reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_passengers_passenger_id",
                table: "reservation_passengers",
                column: "passenger_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_passengers_reservation_id",
                table: "reservation_passengers",
                column: "reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_status_transitions_from_reservation_status_id",
                table: "reservation_status_transitions",
                column: "from_reservation_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_status_transitions_reservation_id",
                table: "reservation_status_transitions",
                column: "reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_status_transitions_to_reservation_status_id",
                table: "reservation_status_transitions",
                column: "to_reservation_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_statuses_name",
                table: "reservation_statuses",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reservations_client_id",
                table: "reservations",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_reservation_code",
                table: "reservations",
                column: "reservation_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reservations_reservation_status_id",
                table: "reservations",
                column: "reservation_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_road_types_name",
                table: "road_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_role_permissions_permission_id",
                table: "role_permissions",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_permissions_role_id",
                table: "role_permissions",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_roles_code",
                table: "roles",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_route_stops_airport_id",
                table: "route_stops",
                column: "airport_id");

            migrationBuilder.CreateIndex(
                name: "IX_route_stops_route_id",
                table: "route_stops",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_routes_destination_airport_id",
                table: "routes",
                column: "destination_airport_id");

            migrationBuilder.CreateIndex(
                name: "IX_routes_origin_airport_id",
                table: "routes",
                column: "origin_airport_id");

            migrationBuilder.CreateIndex(
                name: "IX_seasons_name",
                table: "seasons",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_seat_location_types_name",
                table: "seat_location_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sessions_token",
                table: "sessions",
                column: "token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sessions_user_id",
                table: "sessions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_staff_employee_code",
                table: "staff",
                column: "employee_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_staff_person_id",
                table: "staff",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_staff_staff_position_id",
                table: "staff",
                column: "staff_position_id");

            migrationBuilder.CreateIndex(
                name: "IX_staff_availabilities_availability_status_id",
                table: "staff_availabilities",
                column: "availability_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_staff_availabilities_staff_id",
                table: "staff_availabilities",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_staff_positions_name",
                table: "staff_positions",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ticket_statuses_name",
                table: "ticket_statuses",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tickets_flight_id",
                table: "tickets",
                column: "flight_id");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_passenger_id",
                table: "tickets",
                column: "passenger_id");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_reservation_id",
                table: "tickets",
                column: "reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_ticket_number",
                table: "tickets",
                column: "ticket_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tickets_ticket_status_id",
                table: "tickets",
                column: "ticket_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_person_id",
                table: "users",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                table: "users",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_user_name",
                table: "users",
                column: "user_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "airport_airlines");

            migrationBuilder.DropTable(
                name: "cabin_configurations");

            migrationBuilder.DropTable(
                name: "check_ins");

            migrationBuilder.DropTable(
                name: "fares");

            migrationBuilder.DropTable(
                name: "flight_assignments");

            migrationBuilder.DropTable(
                name: "flight_status_transitions");

            migrationBuilder.DropTable(
                name: "invoice_items");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "person_emails");

            migrationBuilder.DropTable(
                name: "person_phones");

            migrationBuilder.DropTable(
                name: "reservation_flights");

            migrationBuilder.DropTable(
                name: "reservation_passengers");

            migrationBuilder.DropTable(
                name: "reservation_status_transitions");

            migrationBuilder.DropTable(
                name: "role_permissions");

            migrationBuilder.DropTable(
                name: "route_stops");

            migrationBuilder.DropTable(
                name: "seasons");

            migrationBuilder.DropTable(
                name: "sessions");

            migrationBuilder.DropTable(
                name: "staff_availabilities");

            migrationBuilder.DropTable(
                name: "check_in_statuses");

            migrationBuilder.DropTable(
                name: "flight_seats");

            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "flight_roles");

            migrationBuilder.DropTable(
                name: "invoice_item_types");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "payment_methods");

            migrationBuilder.DropTable(
                name: "payment_statuses");

            migrationBuilder.DropTable(
                name: "email_domains");

            migrationBuilder.DropTable(
                name: "phone_codes");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "staff");

            migrationBuilder.DropTable(
                name: "cabin_types");

            migrationBuilder.DropTable(
                name: "seat_location_types");

            migrationBuilder.DropTable(
                name: "flights");

            migrationBuilder.DropTable(
                name: "passengers");

            migrationBuilder.DropTable(
                name: "ticket_statuses");

            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "card_issuers");

            migrationBuilder.DropTable(
                name: "card_types");

            migrationBuilder.DropTable(
                name: "payment_method_types");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "staff_positions");

            migrationBuilder.DropTable(
                name: "aircraft");

            migrationBuilder.DropTable(
                name: "flight_statuses");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "passenger_types");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "reservation_statuses");

            migrationBuilder.DropTable(
                name: "aircraft_models");

            migrationBuilder.DropTable(
                name: "availability_statuses");

            migrationBuilder.DropTable(
                name: "airports");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "aircraft_manufacturers");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "document_types");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "road_types");

            migrationBuilder.DropTable(
                name: "regions");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
