using AirlineTicketSystem.Api.Dtos.RolePermissions;
using AirlineTicketSystem.Application.UseCases.RolePermission;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class RolePermissionsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public RolePermissionsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<RolePermissionDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<RolePermissionDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetRolePermissionsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<RolePermissionDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(RolePermissionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolePermissionDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetRolePermissionByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<RolePermissionDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(RolePermissionDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolePermissionDto>> Create(CreateRolePermissionRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateRolePermissionCommand(request.RoleId, request.PermissionId), cancellationToken);
        var entity = await _sender.Send(new GetRolePermissionByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<RolePermissionDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateRolePermissionRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateRolePermissionCommand(id, request.RoleId, request.PermissionId, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteRolePermissionCommand(id), cancellationToken);

        return NoContent();
    }
}
