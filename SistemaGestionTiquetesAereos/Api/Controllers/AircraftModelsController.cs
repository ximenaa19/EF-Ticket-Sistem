using AirlineTicketSystem.Api.Dtos.AircraftModels;
using AirlineTicketSystem.Application.UseCases.AircraftModel;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AircraftModelsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AircraftModelsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<AircraftModelDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<AircraftModelDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetAircraftModelsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<AircraftModelDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AircraftModelDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AircraftModelDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetAircraftModelByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<AircraftModelDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(AircraftModelDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AircraftModelDto>> Create(CreateAircraftModelRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateAircraftModelCommand(request.Name, request.AircraftManufacturerId), cancellationToken);
        var entity = await _sender.Send(new GetAircraftModelByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<AircraftModelDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateAircraftModelRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateAircraftModelCommand(id, request.Name, request.AircraftManufacturerId, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteAircraftModelCommand(id), cancellationToken);

        return NoContent();
    }
}
