using AirlineTicketSystem.Api.Dtos.PhoneCodes;
using AirlineTicketSystem.Application.UseCases.PhoneCode;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PhoneCodesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public PhoneCodesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PhoneCodeDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PhoneCodeDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetPhoneCodesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<PhoneCodeDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PhoneCodeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PhoneCodeDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetPhoneCodeByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<PhoneCodeDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(PhoneCodeDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PhoneCodeDto>> Create(CreatePhoneCodeRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreatePhoneCodeCommand(request.CountryId, request.Code), cancellationToken);
        var entity = await _sender.Send(new GetPhoneCodeByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<PhoneCodeDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdatePhoneCodeRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdatePhoneCodeCommand(id, request.CountryId, request.Code, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeletePhoneCodeCommand(id), cancellationToken);

        return NoContent();
    }
}
