using AirlineTicketSystem.Api.Dtos.ReservationStatusTransitions;
using AirlineTicketSystem.Application.UseCases.ReservationStatusTransition;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ReservationStatusTransitionsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public ReservationStatusTransitionsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ReservationStatusTransitionDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ReservationStatusTransitionDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetReservationStatusTransitionsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<ReservationStatusTransitionDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ReservationStatusTransitionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReservationStatusTransitionDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetReservationStatusTransitionByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<ReservationStatusTransitionDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ReservationStatusTransitionDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReservationStatusTransitionDto>> Create(CreateReservationStatusTransitionRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateReservationStatusTransitionCommand(request.ReservationId, request.FromReservationStatusId, request.ToReservationStatusId, request.ChangedAt), cancellationToken);
        var entity = await _sender.Send(new GetReservationStatusTransitionByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<ReservationStatusTransitionDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateReservationStatusTransitionRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateReservationStatusTransitionCommand(id, request.ReservationId, request.FromReservationStatusId, request.ToReservationStatusId, request.ChangedAt, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteReservationStatusTransitionCommand(id), cancellationToken);

        return NoContent();
    }
}
