using AirlineTicketSystem.Api.Dtos.PassengerTypes;
using AirlineTicketSystem.Application.UseCases.PassengerType;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PassengerTypesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public PassengerTypesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PassengerTypeDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PassengerTypeDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetPassengerTypesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<PassengerTypeDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PassengerTypeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PassengerTypeDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetPassengerTypeByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<PassengerTypeDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(PassengerTypeDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PassengerTypeDto>> Create(CreatePassengerTypeRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreatePassengerTypeCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetPassengerTypeByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<PassengerTypeDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdatePassengerTypeRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdatePassengerTypeCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeletePassengerTypeCommand(id), cancellationToken);

        return NoContent();
    }
}
