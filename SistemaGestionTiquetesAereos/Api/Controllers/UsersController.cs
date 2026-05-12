using AirlineTicketSystem.Api.Dtos.Users;
using AirlineTicketSystem.Application.UseCases.User;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class UsersController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public UsersController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<UserDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<UserDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetUsersQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<UserDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetUserByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<UserDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserDto>> Create(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateUserCommand(request.PersonId, request.RoleId, request.UserName, request.PasswordHash), cancellationToken);
        var entity = await _sender.Send(new GetUserByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<UserDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateUserCommand(id, request.PersonId, request.RoleId, request.UserName, request.PasswordHash, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteUserCommand(id), cancellationToken);

        return NoContent();
    }
}
