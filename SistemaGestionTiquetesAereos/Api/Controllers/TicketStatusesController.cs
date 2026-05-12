using AirlineTicketSystem.Api.Dtos.TicketStatuses;
using AirlineTicketSystem.Application.UseCases.TicketStatus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class TicketStatusesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public TicketStatusesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<TicketStatusDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<TicketStatusDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetTicketStatusesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<TicketStatusDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(TicketStatusDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TicketStatusDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetTicketStatusByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<TicketStatusDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(TicketStatusDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TicketStatusDto>> Create(CreateTicketStatusRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateTicketStatusCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetTicketStatusByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<TicketStatusDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateTicketStatusRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateTicketStatusCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteTicketStatusCommand(id), cancellationToken);

        return NoContent();
    }
}
