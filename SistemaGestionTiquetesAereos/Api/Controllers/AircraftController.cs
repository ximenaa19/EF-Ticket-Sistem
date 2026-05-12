using AirlineTicketSystem.Api.Dtos.Aircraft;
using AirlineTicketSystem.Application.UseCases.Aircraft;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AircraftController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AircraftController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<AircraftDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<AircraftDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetAircraftQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<AircraftDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AircraftDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AircraftDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetAircraftByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<AircraftDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(AircraftDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AircraftDto>> Create(CreateAircraftRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateAircraftCommand(request.RegistrationNumber, request.AirlineId, request.AircraftModelId, request.AvailabilityStatusId, request.TotalCapacity), cancellationToken);
        var entity = await _sender.Send(new GetAircraftByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<AircraftDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateAircraftRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateAircraftCommand(id, request.RegistrationNumber, request.AirlineId, request.AircraftModelId, request.AvailabilityStatusId, request.TotalCapacity, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteAircraftCommand(id), cancellationToken);

        return NoContent();
    }
}
