using AirlineTicketSystem.Api.Dtos.CheckInStatuses;
using AirlineTicketSystem.Application.UseCases.CheckInStatus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CheckInStatusesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CheckInStatusesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<CheckInStatusDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<CheckInStatusDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetCheckInStatusesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<CheckInStatusDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CheckInStatusDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CheckInStatusDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetCheckInStatusByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<CheckInStatusDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(CheckInStatusDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CheckInStatusDto>> Create(CreateCheckInStatusRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateCheckInStatusCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetCheckInStatusByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<CheckInStatusDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateCheckInStatusRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateCheckInStatusCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteCheckInStatusCommand(id), cancellationToken);

        return NoContent();
    }
}
