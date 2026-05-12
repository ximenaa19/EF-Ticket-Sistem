using AirlineTicketSystem.Api.Dtos.Continents;
using AirlineTicketSystem.Application.UseCases.Continent;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ContinentsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public ContinentsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ContinentDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ContinentDto>>> GetAll(CancellationToken cancellationToken)
    {
        var continents = await _sender.Send(new GetContinentsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<ContinentDto>>(continents));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ContinentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContinentDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var continent = await _sender.Send(new GetContinentByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<ContinentDto>(continent));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ContinentDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContinentDto>> Create(
        CreateContinentRequest request,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateContinentCommand>(request);
        var id = await _sender.Send(command, cancellationToken);
        var continent = await _sender.Send(new GetContinentByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<ContinentDto>(continent));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateContinentRequest request,
        CancellationToken cancellationToken)
    {
        var command = new UpdateContinentCommand(id, request.Name, request.IsActive);

        await _sender.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteContinentCommand(id), cancellationToken);

        return NoContent();
    }
}
