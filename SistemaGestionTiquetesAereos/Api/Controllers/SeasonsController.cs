using AirlineTicketSystem.Api.Dtos.Seasons;
using AirlineTicketSystem.Application.UseCases.Season;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class SeasonsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public SeasonsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<SeasonDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<SeasonDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetSeasonsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<SeasonDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(SeasonDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SeasonDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetSeasonByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<SeasonDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(SeasonDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SeasonDto>> Create(CreateSeasonRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateSeasonCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetSeasonByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<SeasonDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateSeasonRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateSeasonCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteSeasonCommand(id), cancellationToken);

        return NoContent();
    }
}
