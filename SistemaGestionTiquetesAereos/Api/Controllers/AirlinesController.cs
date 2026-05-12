using AirlineTicketSystem.Api.Dtos.Airlines;
using AirlineTicketSystem.Application.UseCases.Airline;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AirlinesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AirlinesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<AirlineDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<AirlineDto>>> GetAll(CancellationToken cancellationToken)
    {
        var airlines = await _sender.Send(new GetAirlinesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<AirlineDto>>(airlines));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AirlineDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AirlineDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var airline = await _sender.Send(new GetAirlineByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<AirlineDto>(airline));
    }

    [HttpPost]
    [ProducesResponseType(typeof(AirlineDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AirlineDto>> Create(
        CreateAirlineRequest request,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateAirlineCommand>(request);
        var id = await _sender.Send(command, cancellationToken);
        var airline = await _sender.Send(new GetAirlineByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<AirlineDto>(airline));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateAirlineRequest request,
        CancellationToken cancellationToken)
    {
        var command = new UpdateAirlineCommand(id, request.Name, request.IataCode, request.IsActive);

        await _sender.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteAirlineCommand(id), cancellationToken);

        return NoContent();
    }
}
