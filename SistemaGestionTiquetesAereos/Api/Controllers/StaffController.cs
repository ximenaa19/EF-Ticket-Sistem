using AirlineTicketSystem.Api.Dtos.Staff;
using AirlineTicketSystem.Application.UseCases.Staff;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class StaffController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public StaffController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<StaffDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<StaffDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetStaffQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<StaffDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(StaffDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StaffDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetStaffByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<StaffDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(StaffDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<StaffDto>> Create(CreateStaffRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateStaffCommand(request.PersonId, request.StaffPositionId, request.EmployeeCode), cancellationToken);
        var entity = await _sender.Send(new GetStaffByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<StaffDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateStaffRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateStaffCommand(id, request.PersonId, request.StaffPositionId, request.EmployeeCode, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteStaffCommand(id), cancellationToken);

        return NoContent();
    }
}
