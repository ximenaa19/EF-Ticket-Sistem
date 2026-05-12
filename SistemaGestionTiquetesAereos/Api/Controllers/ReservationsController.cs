using AirlineTicketSystem.Api.Dtos.Reservations;
using AirlineTicketSystem.Application.UseCases.Reservation;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ReservationsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public ReservationsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ReservationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ReservationDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetReservationsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<ReservationDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ReservationDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReservationDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetReservationByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<ReservationDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ReservationDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReservationDto>> Create(CreateReservationRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateReservationCommand(request.ClientId, request.ReservationStatusId, request.ReservationCode, request.ReservedAt, request.TotalAmount, request.Currency), cancellationToken);
        var entity = await _sender.Send(new GetReservationByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<ReservationDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateReservationRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateReservationCommand(id, request.ClientId, request.ReservationStatusId, request.ReservationCode, request.ReservedAt, request.TotalAmount, request.Currency, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteReservationCommand(id), cancellationToken);

        return NoContent();
    }
}
