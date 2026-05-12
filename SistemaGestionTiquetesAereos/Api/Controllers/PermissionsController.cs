using AirlineTicketSystem.Api.Dtos.Permissions;
using AirlineTicketSystem.Application.UseCases.Permission;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PermissionsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public PermissionsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PermissionDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PermissionDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetPermissionsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<PermissionDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PermissionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PermissionDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetPermissionByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<PermissionDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(PermissionDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PermissionDto>> Create(CreatePermissionRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreatePermissionCommand(request.Name, request.Code), cancellationToken);
        var entity = await _sender.Send(new GetPermissionByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<PermissionDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdatePermissionRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdatePermissionCommand(id, request.Name, request.Code, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeletePermissionCommand(id), cancellationToken);

        return NoContent();
    }
}
