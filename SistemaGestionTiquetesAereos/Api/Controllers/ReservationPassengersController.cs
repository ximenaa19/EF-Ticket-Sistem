using AirlineTicketSystem.Api.Dtos.ReservationPassengers;
using AirlineTicketSystem.Application.UseCases.ReservationPassenger;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ReservationPassengersController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public ReservationPassengersController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ReservationPassengerDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ReservationPassengerDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetReservationPassengersQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<ReservationPassengerDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ReservationPassengerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReservationPassengerDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetReservationPassengerByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<ReservationPassengerDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ReservationPassengerDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReservationPassengerDto>> Create(CreateReservationPassengerRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateReservationPassengerCommand(request.ReservationId, request.PassengerId), cancellationToken);
        var entity = await _sender.Send(new GetReservationPassengerByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<ReservationPassengerDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateReservationPassengerRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateReservationPassengerCommand(id, request.ReservationId, request.PassengerId, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteReservationPassengerCommand(id), cancellationToken);

        return NoContent();
    }
}
