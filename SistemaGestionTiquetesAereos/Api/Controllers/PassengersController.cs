using AirlineTicketSystem.Api.Dtos.Passengers;
using AirlineTicketSystem.Application.UseCases.Passenger;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PassengersController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public PassengersController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PassengerDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PassengerDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetPassengersQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<PassengerDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PassengerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PassengerDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetPassengerByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<PassengerDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(PassengerDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PassengerDto>> Create(CreatePassengerRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreatePassengerCommand(request.PersonId, request.PassengerTypeId), cancellationToken);
        var entity = await _sender.Send(new GetPassengerByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<PassengerDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdatePassengerRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdatePassengerCommand(id, request.PersonId, request.PassengerTypeId, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeletePassengerCommand(id), cancellationToken);

        return NoContent();
    }
}
