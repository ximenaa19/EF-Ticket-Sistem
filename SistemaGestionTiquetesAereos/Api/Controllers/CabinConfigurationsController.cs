using AirlineTicketSystem.Api.Dtos.CabinConfigurations;
using AirlineTicketSystem.Application.UseCases.CabinConfiguration;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CabinConfigurationsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CabinConfigurationsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<CabinConfigurationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<CabinConfigurationDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetCabinConfigurationsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<CabinConfigurationDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CabinConfigurationDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CabinConfigurationDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetCabinConfigurationByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<CabinConfigurationDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(CabinConfigurationDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CabinConfigurationDto>> Create(CreateCabinConfigurationRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateCabinConfigurationCommand(request.AircraftId, request.CabinTypeId, request.SeatCount), cancellationToken);
        var entity = await _sender.Send(new GetCabinConfigurationByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<CabinConfigurationDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateCabinConfigurationRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateCabinConfigurationCommand(id, request.AircraftId, request.CabinTypeId, request.SeatCount, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteCabinConfigurationCommand(id), cancellationToken);

        return NoContent();
    }
}
