using AirlineTicketSystem.Api.Dtos.FlightStatuses;
using AirlineTicketSystem.Application.UseCases.FlightStatus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class FlightStatusesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public FlightStatusesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<FlightStatusDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<FlightStatusDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetFlightStatusesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<FlightStatusDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FlightStatusDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FlightStatusDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetFlightStatusByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<FlightStatusDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(FlightStatusDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FlightStatusDto>> Create(CreateFlightStatusRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateFlightStatusCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetFlightStatusByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<FlightStatusDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateFlightStatusRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateFlightStatusCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteFlightStatusCommand(id), cancellationToken);

        return NoContent();
    }
}
