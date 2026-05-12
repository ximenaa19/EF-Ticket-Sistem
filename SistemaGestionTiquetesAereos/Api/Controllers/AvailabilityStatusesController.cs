using AirlineTicketSystem.Api.Dtos.AvailabilityStatuses;
using AirlineTicketSystem.Application.UseCases.AvailabilityStatus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AvailabilityStatusesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AvailabilityStatusesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<AvailabilityStatusDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<AvailabilityStatusDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetAvailabilityStatusesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<AvailabilityStatusDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AvailabilityStatusDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AvailabilityStatusDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetAvailabilityStatusByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<AvailabilityStatusDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(AvailabilityStatusDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AvailabilityStatusDto>> Create(CreateAvailabilityStatusRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateAvailabilityStatusCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetAvailabilityStatusByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<AvailabilityStatusDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateAvailabilityStatusRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateAvailabilityStatusCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteAvailabilityStatusCommand(id), cancellationToken);

        return NoContent();
    }
}
