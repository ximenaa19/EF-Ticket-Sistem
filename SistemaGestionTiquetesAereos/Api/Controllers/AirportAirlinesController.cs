using AirlineTicketSystem.Api.Dtos.AirportAirlines;
using AirlineTicketSystem.Application.UseCases.AirportAirline;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AirportAirlinesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AirportAirlinesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<AirportAirlineDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<AirportAirlineDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetAirportAirlinesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<AirportAirlineDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AirportAirlineDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AirportAirlineDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetAirportAirlineByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<AirportAirlineDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(AirportAirlineDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AirportAirlineDto>> Create(CreateAirportAirlineRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateAirportAirlineCommand(request.AirportId, request.AirlineId), cancellationToken);
        var entity = await _sender.Send(new GetAirportAirlineByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<AirportAirlineDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateAirportAirlineRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateAirportAirlineCommand(id, request.AirportId, request.AirlineId, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteAirportAirlineCommand(id), cancellationToken);

        return NoContent();
    }
}
