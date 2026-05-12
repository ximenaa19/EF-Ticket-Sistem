using AirlineTicketSystem.Api.Dtos.Addresses;
using AirlineTicketSystem.Application.UseCases.Address;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AddressesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AddressesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<AddressDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<AddressDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetAddressesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<AddressDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AddressDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AddressDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetAddressByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<AddressDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddressDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AddressDto>> Create(CreateAddressRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateAddressCommand(request.RoadTypeId, request.CityId, request.Street, request.Number, request.AdditionalInfo), cancellationToken);
        var entity = await _sender.Send(new GetAddressByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<AddressDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateAddressRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateAddressCommand(id, request.RoadTypeId, request.CityId, request.Street, request.Number, request.AdditionalInfo, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteAddressCommand(id), cancellationToken);

        return NoContent();
    }
}
