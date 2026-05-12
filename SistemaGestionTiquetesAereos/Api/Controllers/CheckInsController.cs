using AirlineTicketSystem.Api.Dtos.CheckIns;
using AirlineTicketSystem.Application.UseCases.CheckIn;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CheckInsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CheckInsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<CheckInDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<CheckInDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetCheckInsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<CheckInDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CheckInDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CheckInDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetCheckInByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<CheckInDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(CheckInDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CheckInDto>> Create(CreateCheckInRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateCheckInCommand(request.TicketId, request.CheckInStatusId, request.SeatId, request.CheckedInAt), cancellationToken);
        var entity = await _sender.Send(new GetCheckInByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<CheckInDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateCheckInRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateCheckInCommand(id, request.TicketId, request.CheckInStatusId, request.SeatId, request.CheckedInAt, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteCheckInCommand(id), cancellationToken);

        return NoContent();
    }
}
