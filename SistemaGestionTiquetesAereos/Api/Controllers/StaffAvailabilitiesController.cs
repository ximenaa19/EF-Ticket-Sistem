using AirlineTicketSystem.Api.Dtos.StaffAvailabilities;
using AirlineTicketSystem.Application.UseCases.StaffAvailability;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class StaffAvailabilitiesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public StaffAvailabilitiesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<StaffAvailabilityDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<StaffAvailabilityDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetStaffAvailabilitiesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<StaffAvailabilityDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(StaffAvailabilityDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StaffAvailabilityDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetStaffAvailabilityByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<StaffAvailabilityDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(StaffAvailabilityDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<StaffAvailabilityDto>> Create(CreateStaffAvailabilityRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateStaffAvailabilityCommand(request.StaffId, request.AvailabilityStatusId, request.AvailableFrom, request.AvailableTo), cancellationToken);
        var entity = await _sender.Send(new GetStaffAvailabilityByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<StaffAvailabilityDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateStaffAvailabilityRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateStaffAvailabilityCommand(id, request.StaffId, request.AvailabilityStatusId, request.AvailableFrom, request.AvailableTo, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteStaffAvailabilityCommand(id), cancellationToken);

        return NoContent();
    }
}
