using AirlineTicketSystem.Api.Dtos.ReservationStatuses;
using AirlineTicketSystem.Application.UseCases.ReservationStatus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ReservationStatusesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public ReservationStatusesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ReservationStatusDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ReservationStatusDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetReservationStatusesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<ReservationStatusDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ReservationStatusDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReservationStatusDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetReservationStatusByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<ReservationStatusDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ReservationStatusDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReservationStatusDto>> Create(CreateReservationStatusRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateReservationStatusCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetReservationStatusByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<ReservationStatusDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateReservationStatusRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateReservationStatusCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteReservationStatusCommand(id), cancellationToken);

        return NoContent();
    }
}
