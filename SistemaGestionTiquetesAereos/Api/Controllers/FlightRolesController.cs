using AirlineTicketSystem.Api.Dtos.FlightRoles;
using AirlineTicketSystem.Application.UseCases.FlightRole;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class FlightRolesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public FlightRolesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<FlightRoleDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<FlightRoleDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetFlightRolesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<FlightRoleDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FlightRoleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FlightRoleDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetFlightRoleByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<FlightRoleDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(FlightRoleDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FlightRoleDto>> Create(CreateFlightRoleRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateFlightRoleCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetFlightRoleByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<FlightRoleDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateFlightRoleRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateFlightRoleCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteFlightRoleCommand(id), cancellationToken);

        return NoContent();
    }
}
