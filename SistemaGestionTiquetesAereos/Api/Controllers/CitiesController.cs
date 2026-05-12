using AirlineTicketSystem.Api.Dtos.Cities;
using AirlineTicketSystem.Application.UseCases.City;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CitiesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CitiesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<CityDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<CityDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetCitiesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<CityDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CityDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CityDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetCityByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<CityDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(CityDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CityDto>> Create(CreateCityRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateCityCommand(request.Name, request.RegionId), cancellationToken);
        var entity = await _sender.Send(new GetCityByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<CityDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateCityRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateCityCommand(id, request.Name, request.RegionId, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteCityCommand(id), cancellationToken);

        return NoContent();
    }
}
