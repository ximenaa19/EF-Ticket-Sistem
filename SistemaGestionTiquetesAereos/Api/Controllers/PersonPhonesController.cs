using AirlineTicketSystem.Api.Dtos.PersonPhones;
using AirlineTicketSystem.Application.UseCases.PersonPhone;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PersonPhonesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public PersonPhonesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PersonPhoneDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PersonPhoneDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetPersonPhonesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<PersonPhoneDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PersonPhoneDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonPhoneDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetPersonPhoneByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<PersonPhoneDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(PersonPhoneDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonPhoneDto>> Create(CreatePersonPhoneRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreatePersonPhoneCommand(request.PersonId, request.PhoneCodeId, request.Number, request.IsPrimary), cancellationToken);
        var entity = await _sender.Send(new GetPersonPhoneByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<PersonPhoneDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdatePersonPhoneRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdatePersonPhoneCommand(id, request.PersonId, request.PhoneCodeId, request.Number, request.IsPrimary, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeletePersonPhoneCommand(id), cancellationToken);

        return NoContent();
    }
}
