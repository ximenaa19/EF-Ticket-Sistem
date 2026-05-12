using AirlineTicketSystem.Api.Dtos.StaffPositions;
using AirlineTicketSystem.Application.UseCases.StaffPosition;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class StaffPositionsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public StaffPositionsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<StaffPositionDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<StaffPositionDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetStaffPositionsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<StaffPositionDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(StaffPositionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StaffPositionDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetStaffPositionByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<StaffPositionDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(StaffPositionDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<StaffPositionDto>> Create(CreateStaffPositionRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateStaffPositionCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetStaffPositionByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<StaffPositionDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateStaffPositionRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateStaffPositionCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteStaffPositionCommand(id), cancellationToken);

        return NoContent();
    }
}
