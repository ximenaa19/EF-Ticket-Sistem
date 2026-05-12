using AirlineTicketSystem.Api.Dtos.Roles;
using AirlineTicketSystem.Application.UseCases.Role;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class RolesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public RolesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<RoleDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<RoleDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetRolesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<RoleDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(RoleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RoleDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetRoleByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<RoleDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(RoleDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RoleDto>> Create(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateRoleCommand(request.Name, request.Code), cancellationToken);
        var entity = await _sender.Send(new GetRoleByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<RoleDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateRoleRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateRoleCommand(id, request.Name, request.Code, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteRoleCommand(id), cancellationToken);

        return NoContent();
    }
}
