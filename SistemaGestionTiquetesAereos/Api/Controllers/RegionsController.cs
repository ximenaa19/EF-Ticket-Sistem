using AirlineTicketSystem.Api.Dtos.Regions;
using AirlineTicketSystem.Application.UseCases.Region;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class RegionsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public RegionsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<RegionDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<RegionDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetRegionsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<RegionDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(RegionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RegionDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetRegionByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<RegionDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(RegionDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RegionDto>> Create(CreateRegionRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateRegionCommand(request.Name, request.CountryId), cancellationToken);
        var entity = await _sender.Send(new GetRegionByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<RegionDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateRegionRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateRegionCommand(id, request.Name, request.CountryId, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteRegionCommand(id), cancellationToken);

        return NoContent();
    }
}
