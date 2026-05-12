using AirlineTicketSystem.Api.Dtos.Sessions;
using AirlineTicketSystem.Application.UseCases.Session;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class SessionsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public SessionsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<SessionDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<SessionDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetSessionsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<SessionDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(SessionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SessionDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetSessionByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<SessionDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(SessionDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SessionDto>> Create(CreateSessionRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateSessionCommand(request.UserId, request.Token, request.ExpiresAt, request.RevokedAt), cancellationToken);
        var entity = await _sender.Send(new GetSessionByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<SessionDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateSessionRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateSessionCommand(id, request.UserId, request.Token, request.ExpiresAt, request.RevokedAt, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteSessionCommand(id), cancellationToken);

        return NoContent();
    }
}
