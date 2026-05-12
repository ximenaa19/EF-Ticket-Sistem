using AirlineTicketSystem.Api.Dtos.RoadTypes;
using AirlineTicketSystem.Application.UseCases.RoadType;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class RoadTypesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public RoadTypesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<RoadTypeDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<RoadTypeDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetRoadTypesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<RoadTypeDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(RoadTypeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RoadTypeDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetRoadTypeByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<RoadTypeDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(RoadTypeDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RoadTypeDto>> Create(CreateRoadTypeRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateRoadTypeCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetRoadTypeByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<RoadTypeDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateRoadTypeRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateRoadTypeCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteRoadTypeCommand(id), cancellationToken);

        return NoContent();
    }
}
