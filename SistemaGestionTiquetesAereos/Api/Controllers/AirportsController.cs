using AirlineTicketSystem.Api.Dtos.Airports;
using AirlineTicketSystem.Application.UseCases.Airport;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AirportsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AirportsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<AirportDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<AirportDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetAirportsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<AirportDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AirportDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AirportDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetAirportByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<AirportDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(AirportDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AirportDto>> Create(CreateAirportRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateAirportCommand(request.Name, request.IataCode, request.IcaoCode, request.CityId), cancellationToken);
        var entity = await _sender.Send(new GetAirportByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<AirportDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateAirportRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateAirportCommand(id, request.Name, request.IataCode, request.IcaoCode, request.CityId, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteAirportCommand(id), cancellationToken);

        return NoContent();
    }
}
