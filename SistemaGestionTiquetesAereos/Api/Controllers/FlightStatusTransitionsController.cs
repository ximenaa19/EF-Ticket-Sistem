using AirlineTicketSystem.Api.Dtos.FlightStatusTransitions;
using AirlineTicketSystem.Application.UseCases.FlightStatusTransition;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class FlightStatusTransitionsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public FlightStatusTransitionsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<FlightStatusTransitionDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<FlightStatusTransitionDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetFlightStatusTransitionsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<FlightStatusTransitionDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FlightStatusTransitionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FlightStatusTransitionDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetFlightStatusTransitionByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<FlightStatusTransitionDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(FlightStatusTransitionDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FlightStatusTransitionDto>> Create(CreateFlightStatusTransitionRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateFlightStatusTransitionCommand(request.FlightId, request.FromFlightStatusId, request.ToFlightStatusId, request.ChangedAt), cancellationToken);
        var entity = await _sender.Send(new GetFlightStatusTransitionByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<FlightStatusTransitionDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateFlightStatusTransitionRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateFlightStatusTransitionCommand(id, request.FlightId, request.FromFlightStatusId, request.ToFlightStatusId, request.ChangedAt, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteFlightStatusTransitionCommand(id), cancellationToken);

        return NoContent();
    }
}
