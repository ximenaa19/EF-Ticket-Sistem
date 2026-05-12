using AirlineTicketSystem.Api.Dtos.Flights;
using AirlineTicketSystem.Application.UseCases.Flight;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class FlightsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public FlightsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<FlightDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<FlightDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetFlightsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<FlightDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FlightDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FlightDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetFlightByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<FlightDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(FlightDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FlightDto>> Create(CreateFlightRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateFlightCommand(request.FlightCode, request.AirlineId, request.RouteId, request.AircraftId, request.DepartureDate, request.EstimatedArrivalDate, request.TotalCapacity, request.AvailableSeats, request.FlightStatusId), cancellationToken);
        var entity = await _sender.Send(new GetFlightByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<FlightDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateFlightRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateFlightCommand(id, request.FlightCode, request.AirlineId, request.RouteId, request.AircraftId, request.DepartureDate, request.EstimatedArrivalDate, request.TotalCapacity, request.AvailableSeats, request.FlightStatusId, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteFlightCommand(id), cancellationToken);

        return NoContent();
    }
}
