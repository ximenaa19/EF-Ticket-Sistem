using AirlineTicketSystem.Api.Dtos.ReservationFlights;
using AirlineTicketSystem.Application.UseCases.ReservationFlight;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ReservationFlightsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public ReservationFlightsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ReservationFlightDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ReservationFlightDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetReservationFlightsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<ReservationFlightDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ReservationFlightDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReservationFlightDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetReservationFlightByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<ReservationFlightDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ReservationFlightDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReservationFlightDto>> Create(CreateReservationFlightRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateReservationFlightCommand(request.ReservationId, request.FlightId), cancellationToken);
        var entity = await _sender.Send(new GetReservationFlightByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<ReservationFlightDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateReservationFlightRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateReservationFlightCommand(id, request.ReservationId, request.FlightId, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteReservationFlightCommand(id), cancellationToken);

        return NoContent();
    }
}
