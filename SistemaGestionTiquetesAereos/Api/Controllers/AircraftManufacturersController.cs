using AirlineTicketSystem.Api.Dtos.AircraftManufacturers;
using AirlineTicketSystem.Application.UseCases.AircraftManufacturer;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AircraftManufacturersController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AircraftManufacturersController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<AircraftManufacturerDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<AircraftManufacturerDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetAircraftManufacturersQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<AircraftManufacturerDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AircraftManufacturerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AircraftManufacturerDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetAircraftManufacturerByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<AircraftManufacturerDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(AircraftManufacturerDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AircraftManufacturerDto>> Create(CreateAircraftManufacturerRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateAircraftManufacturerCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetAircraftManufacturerByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<AircraftManufacturerDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateAircraftManufacturerRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateAircraftManufacturerCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteAircraftManufacturerCommand(id), cancellationToken);

        return NoContent();
    }
}
