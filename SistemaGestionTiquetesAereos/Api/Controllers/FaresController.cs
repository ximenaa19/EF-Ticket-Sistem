using AirlineTicketSystem.Api.Dtos.Fares;
using AirlineTicketSystem.Application.UseCases.Fare;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class FaresController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public FaresController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<FareDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<FareDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetFaresQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<FareDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FareDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FareDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetFareByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<FareDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(FareDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FareDto>> Create(CreateFareRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateFareCommand(request.FlightId, request.PassengerTypeId, request.CabinTypeId, request.Amount, request.Currency), cancellationToken);
        var entity = await _sender.Send(new GetFareByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<FareDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateFareRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateFareCommand(id, request.FlightId, request.PassengerTypeId, request.CabinTypeId, request.Amount, request.Currency, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteFareCommand(id), cancellationToken);

        return NoContent();
    }
}
