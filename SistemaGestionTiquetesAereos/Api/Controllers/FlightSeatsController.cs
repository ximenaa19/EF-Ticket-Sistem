using AirlineTicketSystem.Api.Dtos.FlightSeats;
using AirlineTicketSystem.Application.UseCases.FlightSeat;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class FlightSeatsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public FlightSeatsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<FlightSeatDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<FlightSeatDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetFlightSeatsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<FlightSeatDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FlightSeatDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FlightSeatDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetFlightSeatByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<FlightSeatDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(FlightSeatDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FlightSeatDto>> Create(CreateFlightSeatRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateFlightSeatCommand(request.FlightId, request.SeatNumber, request.CabinTypeId, request.SeatLocationTypeId, request.AvailabilityStatusId), cancellationToken);
        var entity = await _sender.Send(new GetFlightSeatByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<FlightSeatDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateFlightSeatRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateFlightSeatCommand(id, request.FlightId, request.SeatNumber, request.CabinTypeId, request.SeatLocationTypeId, request.AvailabilityStatusId, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteFlightSeatCommand(id), cancellationToken);

        return NoContent();
    }
}
