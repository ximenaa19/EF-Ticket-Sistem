using AirlineTicketSystem.Api.Dtos.Clients;
using AirlineTicketSystem.Application.UseCases.Client;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ClientsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public ClientsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ClientDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ClientDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetClientsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<ClientDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ClientDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClientDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetClientByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<ClientDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ClientDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientDto>> Create(CreateClientRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateClientCommand(request.PersonId), cancellationToken);
        var entity = await _sender.Send(new GetClientByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<ClientDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateClientRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateClientCommand(id, request.PersonId, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteClientCommand(id), cancellationToken);

        return NoContent();
    }
}
