using AirlineTicketSystem.Api.Dtos.EmailDomains;
using AirlineTicketSystem.Application.UseCases.EmailDomain;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class EmailDomainsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public EmailDomainsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<EmailDomainDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<EmailDomainDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetEmailDomainsQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<EmailDomainDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(EmailDomainDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmailDomainDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetEmailDomainByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<EmailDomainDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(EmailDomainDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmailDomainDto>> Create(CreateEmailDomainRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateEmailDomainCommand(request.Name), cancellationToken);
        var entity = await _sender.Send(new GetEmailDomainByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<EmailDomainDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateEmailDomainRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateEmailDomainCommand(id, request.Name, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteEmailDomainCommand(id), cancellationToken);

        return NoContent();
    }
}
