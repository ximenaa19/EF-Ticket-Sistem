using AirlineTicketSystem.Api.Dtos.FlightAssignments;
using AirlineTicketSystem.Application.UseCases.FlightAssignment;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class FlightAssignmentsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public FlightAssignmentsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<FlightAssignmentDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<FlightAssignmentDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetFlightAssignmentsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<FlightAssignmentDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FlightAssignmentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FlightAssignmentDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetFlightAssignmentByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<FlightAssignmentDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(FlightAssignmentDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FlightAssignmentDto>> Create(CreateFlightAssignmentRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateFlightAssignmentCommand(request.FlightId, request.StaffId, request.FlightRoleId), cancellationToken);
        var entity = await _sender.Send(new GetFlightAssignmentByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<FlightAssignmentDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateFlightAssignmentRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateFlightAssignmentCommand(id, request.FlightId, request.StaffId, request.FlightRoleId, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteFlightAssignmentCommand(id), cancellationToken);

        return NoContent();
    }
}
